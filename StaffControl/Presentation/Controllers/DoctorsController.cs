using Microsoft.AspNetCore.Mvc;
using StaffControl.Application.DTOs.DoctorDTOs;
using StaffControl.Application.Interfaces;

namespace StaffControl.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            return doctor == null 
                ? NotFound( new { error = "Patient not found."}) 
                : Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto createDoctorDto)
        {
            await _doctorService.AddAsync(createDoctorDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            return await _doctorService.DeleteAsync(id)
                ? NoContent()
                : NotFound(new { error = $"Doctor with ID {id} not found." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(Guid id, [FromBody] UpdateDoctorDto updateDoctorDto)
        {
            return await _doctorService.UpdateAsync(updateDoctorDto, id)
                ? NoContent()
                : NotFound(new { error = $"Doctor with ID {id} not found." });
        }
    }
}
