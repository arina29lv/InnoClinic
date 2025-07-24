using AppointmentControl.Application.DTOs;
using AppointmentControl.Application.Interfaces;
using AppointmentControl.Domain.Entities;
using AppointmentControl.Domain.Interfaces;
using AutoMapper;
using Contracts.Logs.Interfaces;

namespace AppointmentControl.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogService _logger;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, ILogService logger)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                _logger.LogWarning($"Appointment with ID {id} was not found.");
            }

            return appointment;
        }

        public async Task AddAsync(CreateAppointmentDto createAppointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(createAppointmentDto);

            await _appointmentRepository.AddAsync(appointment);
            _logger.LogInfo($"Appointment with ID {appointment.Id} was created for patient {appointment.PatientId} and doctor {appointment.DoctorId} on {appointment.Date} at {appointment.Time}.");
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                _logger.LogWarning($"Appointment with ID {id} was not found while attempting to delete.");
                return false;
            }

            await _appointmentRepository.DeleteAsync(id);
            _logger.LogInfo($"Appointment with ID {id} was deleted.");
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateAppointmentDto updateAppointmentDto, Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                _logger.LogWarning($"Appointment with ID {id} was not found while attempting to update.");
                return false;
            }

            _mapper.Map(updateAppointmentDto, appointment);

            await _appointmentRepository.UpdateAsync(appointment);
            _logger.LogInfo($"Appointment with ID {id} was updated.");
            return true;
        }
    }
}
