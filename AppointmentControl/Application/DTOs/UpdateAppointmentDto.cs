namespace AppointmentControl.Application.DTOs
{
    public record UpdateAppointmentDto
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsApproved { get; set; }
    }
}
