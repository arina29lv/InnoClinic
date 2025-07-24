using AppointmentControl.Application.DTOs;
using AppointmentControl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentControl.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            return appointment == null
                ? NotFound( new { error = $"Appointment with ID {id} not found."})
                : Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            await _appointmentService.AddAsync(createAppointmentDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            return await _appointmentService.DeleteAsync(id)
                ? NoContent()
                : NotFound(new { error = $"Appointment with ID {id} not found." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] UpdateAppointmentDto updateAppointmentDto)
        {
            return await _appointmentService.UpdateAsync(updateAppointmentDto, id)
                ? NoContent()
                : NotFound(new { error = $"Appointment with ID {id} not found." });
        }
    }
}
