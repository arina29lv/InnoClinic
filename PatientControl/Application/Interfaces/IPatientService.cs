using PatientControl.Application.DTOs;
using PatientControl.Domain.Entities;

namespace PatientControl.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(Guid id);
        Task AddAsync(CreatePatientDto createPatientDto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(UpdatePatientDto updatePatientDto, Guid id);
        Task<Patient> GetByAccountIdAsync(Guid accountId);
    }
}
