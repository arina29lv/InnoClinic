using AppointmentControl.Domain.Entities;

namespace AppointmentControl.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(Guid id);
        Task AddAsync(Appointment appointment);
        Task<bool> DeleteAsync (Guid id);
        Task UpdateAsync(Appointment appointment);
    }
}
