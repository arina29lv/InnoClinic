using AccountControl.Domain.Entities;

namespace AccountControl.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(Guid id);
        Task AddAsync(Account account);
        Task<bool> DeleteAsync(Guid id);
        Task UpdateAsync(Account account);
    }
}
