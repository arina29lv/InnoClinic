using AccountControl.Application.DTOs.Base;

namespace AccountControl.Application.DTOs
{
    public record CreateAccountDto : AccountBase
    {
        public bool IsEmailVerified { get; set; }
        public Guid PhotoId { get; set; }
    }
}
