using AccountControl.Infrastructure.Interfaces;
using Contracts;
using MassTransit;

namespace AccountControl.Infrastructure.Messaging
{
    public class LogMessagePublisher : IRabbitMqLogPublisher
    {
        IPublishEndpoint _publishEndpoint;

        public LogMessagePublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async void SendLog(LogMessageDto log)
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
