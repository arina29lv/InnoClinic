namespace Contracts.DTOs.Auth
{
    public sealed class RegisterRequestDto
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = "Patient";
    }
}
