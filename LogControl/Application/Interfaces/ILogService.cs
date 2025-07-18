using LogControl.Domain.Entity;

namespace LogControl.Application.Interfaces
{
    public interface ILogService
    {
        Task HandleLogAsync(Log log);
    }
}
