namespace Contracts.DTOs.Auth
{
    public sealed class AuthResponseDto
    {
        public string AccessToken { get; set; } = default!;
        public DateTime ExpiresAuth { get; set; }
        public string Type { get; set; } = "Bearer";
        public string Username { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
