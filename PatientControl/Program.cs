using System; 
using PatientControl.Infrastructure.Interfaces;
using PatientControl.Infrastructure.Messaging;
using PatientControl.Infrastructure.Services;
using Contracts.Settings;
using Contracts.Startup;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PatientControl.Application.Interfaces;
using PatientControl.Application.Mappings;
using PatientControl.Application.Services;
using PatientControl.Application.Validators;
using PatientControl.Domain.Interfaces;
using PatientControl.Infrastructure.Middleware;
using PatientControl.Infrastructure.Persistence;
using PatientControl.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PatientDbContext>(options =>
     options.UseSqlServer(
         builder.Configuration.GetConnectionString("DefaultConnection"),
         sql => sql.EnableRetryOnFailure(
             maxRetryCount: 5,
             maxRetryDelay: TimeSpan.FromSeconds(10),
             errorNumbersToAdd: null)));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePatientValidator>();
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
        "PatientControl"));


builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>(); ;

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
    var serviceProvider = scope.ServiceProvider;

    await StartupCheck.ValidateSqlServerAsync(serviceProvider, "DefaultConnection");
    await StartupCheck.ValidateRabbitMqAsync(serviceProvider);

    var db = serviceProvider.GetRequiredService<PatientDbContext>();
    try
    {
        db.Database.Migrate();
    }
    catch
    {
        db.Database.EnsureCreated();
    }
}

app.MapControllers();
app.Run();
