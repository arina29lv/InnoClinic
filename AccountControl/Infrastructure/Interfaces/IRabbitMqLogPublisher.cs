using Contracts;

namespace AccountControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        void SendLog(LogMessageDto log);
    }
}
