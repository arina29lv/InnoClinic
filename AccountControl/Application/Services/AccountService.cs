using AccountControl.Application.DTOs;
using AccountControl.Application.Interfaces;
using AccountControl.Domain.Entities;
using AccountControl.Domain.Interfaces;
using AutoMapper;

namespace AccountControl.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CreateAccountDto createAccountDto)
        {
            var account = _mapper.Map<Account>(createAccountDto);

            account.CreatedAt = DateTime.UtcNow;

            /* TO DO: set current user ID (CreatedBy) from token! */

            await _accountRepository.AddAsync(account);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var account = _accountRepository.GetByIdAsync(id);

            if (account == null)
            {
                return false;
            }

            await _accountRepository.DeleteAsync(id);
            return true;
        }


        public async Task<bool> UpdateAsync(UpdateAccountDto updateAccountDto, Guid id)
        {
            var account = await _accountRepository.GetByIdAsync(id);

            if (account == null)
            {
                return false;
            }

            _mapper.Map(updateAccountDto, account);

            account.UpdatedAt = DateTime.UtcNow;

            /* TO DO: set current user ID (UpdatedBy) from token! */

            await _accountRepository.UpdateAsync(account);
            return true;
        }
    }
}
