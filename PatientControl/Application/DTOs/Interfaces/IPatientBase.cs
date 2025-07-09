namespace PatientControl.Application.DTOs.Interfaces
{
    public interface IPatientBase
    {
        string FirstName { get; }
        string LastName { get; }
        string? MiddleName { get; }
        DateTime DateOfBirth { get; }
    }
}
