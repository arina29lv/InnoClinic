using LogControl.Domain.Entity;
using LogControl.Domain.Interfaces;
using LogControl.Infrastructure.Persistence;

namespace LogControl.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext _context;

        public LogRepository(LogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Log log)
        {
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
