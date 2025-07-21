using AutoMapper;
using Contracts.Logs.Interfaces;
using StaffControl.Application.DTOs.DoctorDTOs;
using StaffControl.Application.Interfaces;
using StaffControl.Domain.Entities;
using StaffControl.Domain.Interfaces;

namespace StaffControl.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper, ILogService logger)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor?> GetByIdAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
            {
                _logger.LogWarning($"Doctor with ID {id} was not found.");
            }

            return doctor;
        }

        public async Task AddAsync(CreateDoctorDto createDoctorDto)
        {
            var doctor = _mapper.Map<Doctor>(createDoctorDto);

            await _doctorRepository.AddAsync(doctor);
            _logger.LogInfo($"Doctor with ID {doctor.Id} was added: {doctor.FirstName} {doctor.LastName}.");
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
            {
                _logger.LogWarning($"Doctor with ID {id} was not found, while attempting to delete.");
                return false;
            }

            await _doctorRepository.DeleteAsync(id);
            _logger.LogInfo($"Doctor with ID {id} was deleted.");
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateDoctorDto updateDoctorDto, Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
            {
                _logger.LogWarning($"Doctor with ID {id} was not found, while attempting to update.");
                return false;
            }

            _mapper.Map(updateDoctorDto, doctor);

            await _doctorRepository.UpdateAsync(doctor);
            _logger.LogInfo($"Doctor with ID {id} was updated.");
            return true;
        }
    }
}
