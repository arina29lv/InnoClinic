namespace Contracts.DTOs.Auth
{
    public sealed class LoginRequestDto
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
