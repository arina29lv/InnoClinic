using LogControl.Infrastructure.Messaging;
using MassTransit;

namespace LogControl.Infrastructure.Configurations
{
    public static class RabbitMqConfig
    {
        public static void AddRabbitMq(this WebApplicationBuilder builder)
        {
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
        }
    }
}
