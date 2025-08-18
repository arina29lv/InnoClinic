using System; 
using Contracts.Settings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StaffControl.Application.Interfaces;
using StaffControl.Application.Mappings;
using StaffControl.Application.Services;
using StaffControl.Application.Validators.DoctorValidator;
using StaffControl.Domain.Interfaces;
using StaffControl.Infrastructure.Interfaces;
using StaffControl.Infrastructure.Messaging;
using StaffControl.Infrastructure.Middleware;
using StaffControl.Infrastructure.Persistence;
using StaffControl.Infrastructure.Repositories;
using StaffControl.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StaffDbContext>(options =>
     options.UseSqlServer(
         builder.Configuration.GetConnectionString("DefaultConnection"),
         sql => sql.EnableRetryOnFailure( 
             maxRetryCount: 5,
             maxRetryDelay: TimeSpan.FromSeconds(10),
             errorNumbersToAdd: null)));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateDoctorValidator>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});

builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMq"));
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        var settings = context.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

        cfg.Host(settings.Host, "/", h =>
        {
            h.Username(settings.Username);
            h.Password(settings.Password);
        });
    });
});
builder.Services.AddScoped<IRabbitMqLogPublisher, RabbitMqLogPublisher>();
builder.Services.AddScoped<ILogService>(sp =>
    new LogService(
        sp.GetRequiredService<IRabbitMqLogPublisher>(),
        sp.GetRequiredService<IHostEnvironment>(),
        "StaffControl"));

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
builder.Services.AddScoped<IReceptionistService, ReceptonistService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExeptionMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StaffDbContext>();
    try { db.Database.Migrate(); } catch { db.Database.EnsureCreated(); }
}

app.MapControllers();
app.Run();
