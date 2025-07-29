using Contracts.Logs.DTOs;

namespace PatientControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        Task SendLog(LogMessageDto log);
    }
}
