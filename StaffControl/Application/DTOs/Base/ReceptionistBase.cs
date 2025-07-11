namespace StaffControl.Application.DTOs.Base
{
    public record ReceptionistBase
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string MiddleName { get; init; }
    }
}
