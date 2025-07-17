using AccountControl.Domain.Entities;
using AccountControl.Domain.Interfaces;
using AccountControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccountControl.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _context;

        public AccountRepository(AccountDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var account = await  _context.Accounts.FindAsync(id);

            if (account != null) {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
