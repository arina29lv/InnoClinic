using Contracts;

namespace PatientControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        void SendLog(LogMessageDto log);
    }
}
