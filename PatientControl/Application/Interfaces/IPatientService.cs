using PatientControl.Application.DTOs;
using PatientControl.Domain.Entities;

namespace PatientControl.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task AddAsync(CreatePatientDto createPatientDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(UpdatePatientDto updatePatientDto, int id);
        Task<Patient> GetByAccountIdAsync(int accountId);
    }
}
