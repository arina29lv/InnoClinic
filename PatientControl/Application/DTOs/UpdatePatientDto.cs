using PatientControl.Application.DTOs.Base;

namespace PatientControl.Application.DTOs
{
    public record UpdatePatientDto : PatientBase
    {
        public bool IsLinkedToAccount { get; set; }
        public Guid AccountId { get; set; }
    }
}
