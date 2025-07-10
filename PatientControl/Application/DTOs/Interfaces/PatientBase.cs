namespace PatientControl.Application.DTOs.Interfaces
{
    public record PatientBase
    {
        string FirstName { get; }
        string LastName { get; }
        string? MiddleName { get; }
        DateTime DateOfBirth { get; }
    }
}
