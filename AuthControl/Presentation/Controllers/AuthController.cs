using AuthControl.Application.Interfaces;
using Contracts.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;

namespace AuthControl.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDto>> Register(
            [FromBody] RegisterRequestDto registerRequestDto, 
            CancellationToken cancellationToken)
        {
            await _authService.RegisterAsync(registerRequestDto, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDto>> Login(
            [FromBody] LoginRequestDto loginRequestDto, 
            CancellationToken cancellationToken)
        {
            var response = await _authService.LoginAsync(loginRequestDto, cancellationToken);
            return Ok(response);
        }

        [HttpGet("me")]
        [Authorize]
        public ActionResult<object> Me()
        {
            var name = User.Identity?.Name;
            var role = User.FindFirstValue(ClaimTypes.Role) ?? User.FindFirst("role")?.Value;

            return Ok(new 
            { 
                Name = name, 
                Role = role 
            });
        }
    }
}
