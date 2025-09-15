using AccountControl.Application.DTOs;
using AccountControl.Application.Interfaces;
using Contracts.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountControl.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            return account == null 
                ? NotFound( new { arror = $"Account with ID {id} not found."}) 
                : Ok(account);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto createAccountDto)
        {
            await _accountService.AddAsync(createAccountDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            return await _accountService.DeleteAsync(id)
                ? NoContent()
                : NotFound( new { error =  $"Account ID {id} not found." });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> UpdateAccount(Guid id, [FromBody] UpdateAccountDto updateAccountDto)
        {
            var account = await _accountService.UpdateAsync(updateAccountDto, id);

            return account == null
                ? NotFound(new { error = $"Account ID {id} not found." })
                : NoContent();
        }
    }
}
