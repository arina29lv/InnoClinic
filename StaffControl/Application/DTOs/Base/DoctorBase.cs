namespace StaffControl.Application.DTOs.Base
{
    public class DoctorBase
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string MiddleName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public DateTime CareerStartYear { get; init; }
        public string ActivityStatus { get; init; }
    }
}
