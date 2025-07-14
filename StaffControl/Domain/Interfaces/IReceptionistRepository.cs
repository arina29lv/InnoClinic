using StaffControl.Domain.Entities;

namespace StaffControl.Domain.Interfaces
{
    public interface IReceptionistRepository
    {
        Task<IEnumerable<Receptionist>> GetAllAsync();
        Task<Receptionist?> GetByIdAsync(Guid id);
        Task AddAsync(Receptionist receptionist);
        Task<bool> DeleteAsync(Guid id);
        Task UpdateAsync(Receptionist receptionist);
    }
}
