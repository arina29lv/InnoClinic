using Contracts.Logs.DTOs;

namespace AppointmentControl.Infrastructure.Interfaces
{
    public interface IRabbitMqLogPublisher
    {
        Task SendLog(LogMessageDto log);
    }
}
