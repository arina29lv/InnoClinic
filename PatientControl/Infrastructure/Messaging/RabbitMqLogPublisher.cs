using Contracts.Logs.DTOs;
using MassTransit;
using PatientControl.Infrastructure.Interfaces;

namespace PatientControl.Infrastructure.Messaging
{
    public class RabbitMqLogPublisher : IRabbitMqLogPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitMqLogPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendLog(LogMessageDto log)
        {
            try
            {
                await _publishEndpoint.Publish(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
