using LogControl.Application.Interfaces;
using LogControl.Domain.Entity;
using LogControl.Domain.Interfaces;

namespace LogControl.Application.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task HandleLogAsync(Log log)
        {
            await _logRepository.AddAsync(log);
        }
    }
}
