using StaffControl.Application.DTOs.ReceptionistDTOs;
using StaffControl.Domain.Entities;

namespace StaffControl.Application.Interfaces
{
    public interface IReceptionistService
    {
        Task<IEnumerable<Receptionist>> GetAllAsync();
        Task<Receptionist?> GetByIdAsync(Guid id);
        Task AddAsync(CreateReceptionistDto createReceptionistDto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(UpdateReceptionistDto updateReceptionistDto, Guid id);
    }
}
