using Contracts.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffControl.Application.DTOs.DoctorDTOs;
using StaffControl.Application.Interfaces;

namespace StaffControl.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            return doctor == null 
                ? NotFound( new { error = "Doctor not found."}) 
                : Ok(doctor);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto createDoctorDto)
        {
            await _doctorService.AddAsync(createDoctorDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            return await _doctorService.DeleteAsync(id)
                ? NoContent()
                : NotFound(new { error = $"Doctor with ID {id} not found." });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Receptionist)]
        public async Task<IActionResult> UpdateDoctor(Guid id, [FromBody] UpdateDoctorDto updateDoctorDto)
        {
            return await _doctorService.UpdateAsync(updateDoctorDto, id)
                ? NoContent()
                : NotFound(new { error = $"Doctor with ID {id} not found." });
        }
    }
}
