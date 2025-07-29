namespace AppointmentControl.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsApproved { get; set; } = false;

    }
}
