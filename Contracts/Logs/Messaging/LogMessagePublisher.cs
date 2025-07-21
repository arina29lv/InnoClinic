using Contracts.Logs.DTOs;
using MassTransit;

namespace Contracts.Logs.Messaging
{
    public class LogMessagePublisher : IRabbitMqLogPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public LogMessagePublisher(IPublishEndpoint publishEndpoint)
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
