using Microsoft.AspNetCore.Mvc;
using StaffControl.Application.DTOs.ReceptionistDTOs;
using StaffControl.Application.Interfaces;

namespace StaffControl.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionistsController : ControllerBase
    {
        private readonly IReceptionistService _receptionistService;

        public ReceptionistsController(IReceptionistService service)
        {
            _receptionistService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReceptionists()
        {
            var receptionist = await _receptionistService.GetAllAsync();
            return Ok(receptionist);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceptionistById(Guid id)
        {
            var receptionist = await _receptionistService.GetByIdAsync(id);
            return receptionist == null
                ? NotFound( new { error = $"Receptionist with ID {id} not found."})
                : Ok(receptionist);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceptionist([FromBody] CreateReceptionistDto createReceptionistDto)
        {
            await _receptionistService.AddAsync(createReceptionistDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceptionist(Guid id)
        {
            return await _receptionistService.DeleteAsync(id)
                ? NoContent()
                : NotFound(new { error = $"Receptionist with ID {id} not found." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceptionist(Guid id, [FromBody] UpdateReceptionistDto updateReceptionistDto)
        {
            return await _receptionistService.UpdateAsync(updateReceptionistDto, id)
                ? NoContent()
                : NotFound(new { error = $"Receptionist with ID {id} not found." });
        }
    }
}
