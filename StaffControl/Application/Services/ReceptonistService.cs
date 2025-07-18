using AutoMapper;
using StaffControl.Application.DTOs.ReceptionistDTOs;
using StaffControl.Application.Interfaces;
using StaffControl.Domain.Entities;
using StaffControl.Domain.Interfaces;
using StaffControl.Infrastructure.Interfaces;

namespace StaffControl.Application.Services
{
    public class ReceptonistService : IReceptionistService
    {
        private readonly IReceptionistRepository _receptionistRepository;
        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        public ReceptonistService(IReceptionistRepository receptionistRepository, IMapper mapper, ILogService logger)
        {
            _receptionistRepository = receptionistRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Receptionist>> GetAllAsync()
        {
            return await _receptionistRepository.GetAllAsync();
        }

        public async Task<Receptionist?> GetByIdAsync(Guid id)
        {
            var receptionist = await _receptionistRepository.GetByIdAsync(id);

            if (receptionist == null)
            {
                _logger.LogWarning($"Receptionist with ID {id} was not found.");
            }

            return receptionist; ;
        }

        public async Task AddAsync(CreateReceptionistDto createReceptionistDto)
        {
            var receptionist = _mapper.Map<Receptionist>(createReceptionistDto);

            await _receptionistRepository.AddAsync(receptionist);
            _logger.LogInfo($"Receptionist with ID {receptionist.Id} was added: {receptionist.FirstName} {receptionist.LastName}.");

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var receptionist = await _receptionistRepository.GetByIdAsync(id);

            if (receptionist == null)
            {
                _logger.LogWarning($"Receptionist with ID {id} was not found, while attempting to delete.");
                return false;
            }

            await _receptionistRepository.DeleteAsync(id);
            _logger.LogInfo($"Receptionist with ID {id} was deleted.");
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateReceptionistDto updateReceptionistDto, Guid id)
        {
            var receptionist = await _receptionistRepository.GetByIdAsync(id);

            if (receptionist == null)
            {
                _logger.LogInfo($"Receptionist with ID {id} was deleted.");
                return false;
            }

            _mapper.Map(updateReceptionistDto, receptionist);

            await _receptionistRepository.UpdateAsync(receptionist);
            _logger.LogInfo($"Receptionist with ID {id} was updated.");
            return true;
        }
    }
}
