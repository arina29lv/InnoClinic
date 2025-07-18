using PatientControl.Application.DTOs.Logs;

namespace PatientControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        void SendLog(LogMessageDto log);
    }
}
