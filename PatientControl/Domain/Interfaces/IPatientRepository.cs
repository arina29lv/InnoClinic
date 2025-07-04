using PatientControl.Domain.Entities;

namespace PatientControl.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync (int id);
        Task AddAsync (Patient patient);
        Task DeleteAsync (int id);
        Task UpdateAsync (Patient patient);
        Task<Patient> GetByAccountIdAsync(int accountId);
    }
}
