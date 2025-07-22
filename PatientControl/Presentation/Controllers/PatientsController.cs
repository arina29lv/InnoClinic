using Microsoft.AspNetCore.Mvc;
using PatientControl.Application.DTOs;
using PatientControl.Application.Interfaces;
using PatientControl.Domain.Entities;

namespace PatientControl.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            return patient == null 
                ? NotFound( new { error = "Patient not found." })
                : Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto createPatientDto)
        {
            await _patientService.AddAsync(createPatientDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            return await _patientService.DeleteAsync(id)
                ? NoContent()
                : NotFound(new { error = $"Patient with ID {id} not found." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] UpdatePatientDto updatePatientDto)
        {
            var patient = await _patientService.UpdateAsync(updatePatientDto, id);
            return patient 
                ? NoContent() 
                : NotFound(new { error = $"Patient with ID {id} not found."});
        }

        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetPatientByAccountId(Guid accountId)
        {
            var patient = await _patientService.GetByAccountIdAsync(accountId);
            return patient == null 
                ? NotFound( new { error = $"Patient with Account ID {accountId} not found."}) 
                : Ok(patient);
        }
    }
}