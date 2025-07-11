using StaffControl.Domain.Entities;

namespace StaffControl.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync (Guid id);
        Task AddAsync (Doctor doctor);
        Task<bool> DeleteAsync (Guid id);
        Task UpdateAsync(Doctor doctor);
    }
}
