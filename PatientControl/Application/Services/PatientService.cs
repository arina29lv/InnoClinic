using PatientControl.Application.DTOs;
using PatientControl.Application.Interfaces;
using PatientControl.Domain.Entities;
using PatientControl.Domain.Interfaces;

namespace PatientControl.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CreatePatientDto createPatientDto)
        {
            var patient = new Patient
            {
                FirstName = createPatientDto.FirstName,
                LastName = createPatientDto.LastName,
                MiddleName = createPatientDto.MiddleName,
                IsLinkedToAccount = createPatientDto.IsLinkedToAccount,
                DateOfBirth = createPatientDto.DateOfBirth,
                AccountId = createPatientDto.AccountId
            };

            await _patientRepository.AddAsync(patient);
        }

        public async Task DeleteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }

        public async Task<bool> UpdateAsync(UpdatePatientDto updatePatientDto, int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return false;
            }

            patient.FirstName = updatePatientDto.FirstName;
            patient.LastName = updatePatientDto.LastName;
            patient.MiddleName = updatePatientDto.MiddleName;
            patient.IsLinkedToAccount = updatePatientDto.IsLinkedToAccount;
            patient.DateOfBirth = updatePatientDto.DateOfBirth;
            patient.AccountId = updatePatientDto.AccountId;

            await _patientRepository.UpdateAsync(patient);
            return true;
        }

        public async Task<Patient> GetByAccountIdAsync(int accountId)
        {
            return await _patientRepository.GetByAccountIdAsync(accountId);
        }

    }
}
