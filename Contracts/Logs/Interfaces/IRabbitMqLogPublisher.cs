using Contracts.Logs.DTOs;

namespace Contracts.Logs.Messaging
{
    public interface IRabbitMqLogPublisher
    {
        Task SendLog(LogMessageDto log);
    }
}
