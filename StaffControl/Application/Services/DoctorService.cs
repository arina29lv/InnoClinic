using AutoMapper;
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

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor?> GetByIdAsync(Guid id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CreateDoctorDto createDoctorDto)
        {
            var doctor = _mapper.Map<Doctor>(createDoctorDto);
            await _doctorRepository.AddAsync(doctor);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
            {
                return false;
            }

            await _doctorRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateDoctorDto updateDoctorDto, Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
            {
                return false;
            }

            _mapper.Map(updateDoctorDto, doctor);

            await _doctorRepository.UpdateAsync(doctor);
            return true;
        }
    }
}
