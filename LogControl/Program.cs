using Contracts.Settings;
using LogControl.Application.Interfaces;
using LogControl.Application.Service;
using LogControl.Domain.Interfaces;
using LogControl.Infrastructure.Messaging;
using LogControl.Infrastructure.Persistence;
using LogControl.Infrastructure.Repositories;
using LogControl.Infrastructure.StartupCheck;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LogDbContext>(options =>
     options.UseSqlServer(
         builder.Configuration.GetConnectionString("DefaultConnection"),
         sql => sql.EnableRetryOnFailure( 
             maxRetryCount: 5,
             maxRetryDelay: TimeSpan.FromSeconds(10),
             errorNumbersToAdd: null)));

builder.Services.AddScoped<LogMessageConsumer>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<LogMessageConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("log_queue", e =>
        {
            e.ConfigureConsumer<LogMessageConsumer>(context);
        });
    });
});

builder.Services.AddScoped<ILogRepository, LogRepository>();
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
