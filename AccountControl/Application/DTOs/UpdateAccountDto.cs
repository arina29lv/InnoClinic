using AccountControl.Application.DTOs.Base;

namespace AccountControl.Application.DTOs
{
    public record UpdateAccountDto : AccountBase
    {
        public bool IsEmailVerified { get; set; }
        public Guid PhotoId { get; set; }
    }
}
