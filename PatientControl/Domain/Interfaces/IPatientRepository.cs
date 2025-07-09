using PatientControl.Domain.Entities;

namespace PatientControl.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync (Guid id);
        Task AddAsync (Patient patient);
        Task<bool> DeleteAsync (Guid id);
        Task UpdateAsync (Patient patient);
        Task<Patient> GetByAccountIdAsync(Guid accountId);
    }
}
