using StaffControl.Application.DTOs.DoctorDTOs;
using StaffControl.Domain.Entities;

namespace StaffControl.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(Guid id);
        Task AddAsync (CreateDoctorDto createDoctorDto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(UpdateDoctorDto updateDoctorDto, Guid id);
    }
}
