using AccountControl.Application.DTOs;
using AccountControl.Domain.Entities;

namespace AccountControl.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(Guid id);
        Task AddAsync(CreateAccountDto createAccountDto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(UpdateAccountDto updateAccountDto, Guid id);
    }
}
