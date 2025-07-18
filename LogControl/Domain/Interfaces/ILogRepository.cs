using LogControl.Domain.Entity;

namespace LogControl.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task AddAsync(Log log);
    }
}
