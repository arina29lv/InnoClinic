using AccountControl.Application.DTOs.Logs;

namespace AccountControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        void SendLog(LogMessageDto log);
    }
}
