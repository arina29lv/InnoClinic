using PatientControl.Application.DTOs.Base;

namespace PatientControl.Application.DTOs
{
    public record CreatePatientDto : PatientBase
    {
        public bool IsLinkedToAccount { get; set; }
        public Guid AccountId { get; set; }

    }
}
