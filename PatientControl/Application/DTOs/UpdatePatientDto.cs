using PatientControl.Application.DTOs.Interfaces;

namespace PatientControl.Application.DTOs
{
    public record UpdatePatientDto : IPatientBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsLinkedToAccount { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid AccountId { get; set; }
    }
}
