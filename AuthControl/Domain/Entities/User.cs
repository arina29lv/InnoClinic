namespace AuthControl.Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = "Patient";
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
