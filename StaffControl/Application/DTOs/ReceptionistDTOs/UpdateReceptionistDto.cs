using StaffControl.Application.DTOs.Base;

namespace StaffControl.Application.DTOs.ReceptionistDTOs
{
    public record UpdateReceptionistDto : ReceptionistBase
    {
        public Guid AccountId { get; set; }
        public Guid OfficeId { get; set; }
    }
}
