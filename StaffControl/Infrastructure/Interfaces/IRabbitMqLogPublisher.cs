using Contracts.Logs.DTOs;

namespace StaffControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        Task SendLog(LogMessageDto log);
    }
}
