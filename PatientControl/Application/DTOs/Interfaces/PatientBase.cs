namespace PatientControl.Application.DTOs.Interfaces
{
    public record PatientBase
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string? MiddleName { get; init; }
        public DateTime DateOfBirth { get; init; }
    }
}
