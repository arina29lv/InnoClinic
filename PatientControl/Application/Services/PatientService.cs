using AutoMapper;
using PatientControl.Application.DTOs;
using PatientControl.Application.Interfaces;
using PatientControl.Domain.Entities;
using PatientControl.Domain.Interfaces;

namespace PatientControl.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
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
            var patient = _mapper.Map<Patient>(createPatientDto);
            await _patientRepository.AddAsync(patient);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) 
            {
                return false;
            }

            await _patientRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> UpdateAsync(UpdatePatientDto updatePatientDto, int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return false;
            }

            _mapper.Map(updatePatientDto, patient);

            await _patientRepository.UpdateAsync(patient);
            return true;
        }

        public async Task<Patient> GetByAccountIdAsync(int accountId)
        {
            return await _patientRepository.GetByAccountIdAsync(accountId);
        }

    }
}
