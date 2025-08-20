using AccountControl.Application.Interfaces;
using AccountControl.Application.Mappings;
using AccountControl.Application.Services;
using AccountControl.Application.Validators;
using AccountControl.Domain.Interfaces;
using AccountControl.Infrastructure.Interfaces;
using AccountControl.Infrastructure.Messaging;
using AccountControl.Infrastructure.Middleware;
using AccountControl.Infrastructure.Persistence;
using AccountControl.Infrastructure.Repositories;
using AccountControl.Infrastructure.Services;
using Contracts.Settings;
using FluentValidation;
using FluentValidation.AspNetCore;
using LogControl.Infrastructure.StartupCheck;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AccountDbContext>(options =>
     options.UseSqlServer(
         builder.Configuration.GetConnectionString("DefaultConnection"),
         sql => sql.EnableRetryOnFailure( 
             maxRetryCount: 5,
             maxRetryDelay: TimeSpan.FromSeconds(10),
             errorNumbersToAdd: null)));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountValidator>();
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
        "AccountControl"));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

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
    var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

    await StartupChecks.ValidateSqlServerAsync(
        config.GetConnectionString("DefaultConnection"));

    var rabbit = scope.ServiceProvider.GetRequiredService<IOptions<RabbitMqSettings>>().Value;
    await StartupChecks.ValidateRabbitMqAsync(rabbit.Host, rabbit.Username, rabbit.Password);
}

app.MapControllers();
app.Run();
