using Contracts.Logs.DTOs;

namespace AccountControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        Task SendLog(LogMessageDto log);
    }
}
