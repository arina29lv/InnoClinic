using AutoMapper;
using StaffControl.Application.DTOs.ReceptionistDTOs;
using StaffControl.Application.Interfaces;
using StaffControl.Domain.Entities;
using StaffControl.Domain.Interfaces;

namespace StaffControl.Application.Services
{
    public class ReceptonistService : IReceptionistService
    {
        private readonly IReceptionistRepository _receptionistRepository;
        private readonly IMapper _mapper;

        public ReceptonistService(IReceptionistRepository receptionistRepository, IMapper mapper)
        {
            _receptionistRepository = receptionistRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Receptionist>> GetAllAsync()
        {
            return await _receptionistRepository.GetAllAsync();
        }

        public async Task<Receptionist?> GetByIdAsync(Guid id)
        {
            return await _receptionistRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(CreateReceptionistDto createReceptionistDto)
        {
            var receptionist = _mapper.Map<Receptionist>(createReceptionistDto);
            await _receptionistRepository.AddAsync(receptionist);

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var receptionist = await _receptionistRepository.GetByIdAsync(id);

            if (receptionist == null)
            {
                return false;
            }

            await _receptionistRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateReceptionistDto updateReceptionistDto, Guid id)
        {
            var receptionist = await _receptionistRepository.GetByIdAsync(id);

            if (receptionist == null)
            {
                return false;
            }

            _mapper.Map(updateReceptionistDto, receptionist);

            await _receptionistRepository.UpdateAsync(receptionist);

            return true;
        }
    }
}
