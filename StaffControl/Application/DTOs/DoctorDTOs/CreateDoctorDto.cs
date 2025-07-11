using StaffControl.Application.DTOs.Base;

namespace StaffControl.Application.DTOs.DoctorDTOs
{
    public class CreateDoctorDto : DoctorBase
    {
        public Guid AccountId { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid OfficeId { get; set; }
    }
}
