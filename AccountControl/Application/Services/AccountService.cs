using AccountControl.Application.DTOs;
using AccountControl.Application.Interfaces;
using AccountControl.Domain.Entities;
using AccountControl.Domain.Interfaces;
using AccountControl.Infrastructure.Interfaces;
using AutoMapper;

namespace AccountControl.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, ILogService logger)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            var account = await _accountRepository.GetByIdAsync(id);

            if (account == null)
            {
                _logger.LogWarning($"Account with ID {id} was not found.");
            }

            return account;
        }

        public async Task AddAsync(CreateAccountDto createAccountDto)
        {
            var account = _mapper.Map<Account>(createAccountDto);

            account.CreatedAt = DateTime.UtcNow;

            /* TO DO: set current user ID (CreatedBy) from token! */

            await _accountRepository.AddAsync(account);
            _logger.LogInfo($"Account with ID {account.Id} was added for user: {account.Email}.");
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var account = _accountRepository.GetByIdAsync(id);

            if (account == null)
            {
                _logger.LogWarning($"Account with ID {id} was not found while attempting to delete.");
                return false;
            }

            await _accountRepository.DeleteAsync(id);
            _logger.LogInfo($"Account with ID {id} was deleted.");
            return true;
        }


        public async Task<bool> UpdateAsync(UpdateAccountDto updateAccountDto, Guid id)
        {
            var account = await _accountRepository.GetByIdAsync(id);

            if (account == null)
            {
                _logger.LogWarning($"Account with ID {id} was not found while attempting to update.");
                return false;
            }

            _mapper.Map(updateAccountDto, account);

            account.UpdatedAt = DateTime.UtcNow;

            /* TO DO: set current user ID (UpdatedBy) from token! */

            await _accountRepository.UpdateAsync(account);
            _logger.LogInfo($"Account with ID {id} was updated.");
            return true;
        }
    }
}
