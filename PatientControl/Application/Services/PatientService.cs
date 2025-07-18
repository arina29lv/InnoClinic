using AutoMapper;
using PatientControl.Application.DTOs;
using PatientControl.Application.Interfaces;
using PatientControl.Domain.Entities;
using PatientControl.Domain.Interfaces;
using PatientControl.Infrastructure.Interfaces;

namespace PatientControl.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        public PatientService(IPatientRepository patientRepository, IMapper mapper, ILogService logger)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient> GetByIdAsync(Guid id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient == null)
            {
                _logger.LogWarning($"Patient with ID {id} was not found.");
            }

            return patient;
        }

        public async Task AddAsync(CreatePatientDto createPatientDto)
        {
            var patient = _mapper.Map<Patient>(createPatientDto);

            await _patientRepository.AddAsync(patient);
            _logger.LogInfo($"Patient with ID {patient.Id} was added: {patient.FirstName} {patient.LastName}.");
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient == null) 
            {
                _logger.LogWarning($"Patient with ID {id} was not found while attempting to delete.");
                return false;
            }

            await _patientRepository.DeleteAsync(id);
            _logger.LogInfo($"Patient with ID {id} was deleted.");
            return true;
        }

        public async Task<bool> UpdateAsync(UpdatePatientDto updatePatientDto, Guid id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient == null)
            {
                _logger.LogWarning($"Patient with ID {id} was not found while attempting to update.");
                return false;
            }

            _mapper.Map(updatePatientDto, patient);

            await _patientRepository.UpdateAsync(patient);
            _logger.LogInfo($"Patient with ID {id} was updated.");
            return true;
        }

        public async Task<Patient> GetByAccountIdAsync(Guid accountId)
        {
            var patient = await _patientRepository.GetByAccountIdAsync(accountId);

            if (patient == null)
            {
                _logger.LogWarning($"Patient with account ID {accountId} was not found.");
            }

            return patient;
        }

    }
}
