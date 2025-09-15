using AuthControl.Application.Interfaces;
using AuthControl.Domain.Entities;
using AuthControl.Domain.Interfaces;
using AuthControl.Infrastructure.interfaces;
using Contracts.DTOs.Auth;
using Microsoft.AspNetCore.Identity;

namespace AuthControl.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly PasswordHasher<User> _passwordHasher = new();

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task RegisterAsync(RegisterRequestDto registerRequest, CancellationToken cancellationToken)
        {
            var username = registerRequest.Username.Trim();
            if (await _userRepository.ExistByUsernameAsync(username, cancellationToken))
            {
                throw new InvalidOperationException("Username already exists.");
            }

            var user = new User
            {
                Username = username,
                Role = registerRequest.Role
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, registerRequest.Password);
            await _userRepository.AddAsync(user, cancellationToken);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequest, CancellationToken cancellationToken)
        {
            var username = loginRequest.Username.Trim();
            var user = await _userRepository.FindByUsernameAsync(username, cancellationToken);
            if (user is null)
            {
                throw new InvalidOperationException("Invalid username or password.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequest.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new InvalidOperationException("Invalid username or password.");
            }

            var (token, expires) = _tokenService.CreateAccessToken(user);
            return new AuthResponseDto
            {
                AccessToken = token,
                ExpiresAuth = expires,
                Username = user.Username,
                Role = user.Role
            };
        }
    }
}