using Contracts.Settings;
using MassTransit;
using Microsoft.Extensions.Options;
using StaffControl.Infrastructure.Interfaces;
using StaffControl.Infrastructure.Messaging;
using StaffControl.Infrastructure.Services;

namespace StaffControl.Infrastructure.Configurations
{
    public static class RabbitMqConfig
    {
        public static void AddRabbitMq(this WebApplicationBuilder builder)
        {
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
        }
    }
}
