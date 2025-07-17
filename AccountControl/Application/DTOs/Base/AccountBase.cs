namespace AccountControl.Application.DTOs.Base
{
    public record AccountBase
    {
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
    }
}