namespace PatientControl.Application.DTOs.Base
{
    public record PatientBase
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string? MiddleName { get; init; }
        public DateTime DateOfBirth { get; init; }
    }
}
