using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using ChubbInsuranceClaim.src.Application.DTO.Authentication;

namespace ChubbInsuranceClaim.src.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            return Ok(new
            {
                message = "User registered successfully.", result
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);

            return Ok(response);
        }
    }
}
