namespace PatientControl.Application.DTOs.Interfaces
{
    public class PatientBase
    {
        string FirstName { get; }
        string LastName { get; }
        string? MiddleName { get; }
        DateTime DateOfBirth { get; }
    }
}
