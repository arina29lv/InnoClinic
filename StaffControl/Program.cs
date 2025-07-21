using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffControl.Application.Interfaces;
using StaffControl.Application.Mappings;
using StaffControl.Application.Services;
using StaffControl.Application.Validators.DoctorValidator;
using StaffControl.Domain.Interfaces;
using StaffControl.Infrastructure.Interfaces;
using StaffControl.Infrastructure.Messaging;
using StaffControl.Infrastructure.Persistence;
using StaffControl.Infrastructure.Repositories;
using StaffControl.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StaffDbContext>(options => 
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateDoctorValidator>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});
builder.Services.AddScoped<IRabbitMqLogPublisher, LogMessagePublisher>();
builder.Services.AddScoped<ILogService, LogService>();


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

app.MapControllers();
app.Run();
