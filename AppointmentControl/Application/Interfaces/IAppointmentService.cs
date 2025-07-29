using AppointmentControl.Application.DTOs;
using AppointmentControl.Domain.Entities;

namespace AppointmentControl.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(Guid id);
        Task AddAsync (CreateAppointmentDto createAppointmentDto);
        Task<bool> DeleteAsync (Guid id);
        Task<bool> UpdateAsync (UpdateAppointmentDto updateAppointmentDto, Guid id);
    }
}
