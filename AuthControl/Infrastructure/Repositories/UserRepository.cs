using AuthControl.Domain.Entities;
using AuthControl.Domain.Interfaces;
using AuthControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthControl.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken) =>
            _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username, cancellationToken);

        public Task<bool> ExistByUsernameAsync(string username, CancellationToken cancellationToken) =>
            _context.Users.AnyAsync(u => u.Username == username, cancellationToken);

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
