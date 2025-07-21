using Contracts;

namespace StaffControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        void SendLog(LogMessageDto log);
    }
}
