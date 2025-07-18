using AccountControl.Application.Interfaces;
using AccountControl.Application.Mappings;
using AccountControl.Application.Services;
using AccountControl.Application.Validators;
using AccountControl.Domain.Interfaces;
using AccountControl.Infrastructure.Interfaces;
using AccountControl.Infrastructure.Messaging;
using AccountControl.Infrastructure.Persistence;
using AccountControl.Infrastructure.Repositories;
using AccountControl.Infrastructure.Service;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AccountDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountValidator>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRabbitMqLogPublisher, RabbitMqLogPublisher>();
builder.Services.AddScoped<ILogService, LogService>();

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
