using Contracts.DTOs.Auth;

namespace AuthControl.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequestDto registerRequest, CancellationToken cancellationToken);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequest, CancellationToken cancellationToken);
    }
}
