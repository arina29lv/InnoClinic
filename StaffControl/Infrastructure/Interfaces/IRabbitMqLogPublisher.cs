using StaffControl.Application.DTOs.Logs;

namespace StaffControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        void SendLog(LogMessageDto log);
    }
}
