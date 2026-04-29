using Microsoft.AspNetCore.Mvc;
using StudentMgmtSystem.Models.Request.Auth;
using StudentMgmtSystem.Services.Auth;

namespace StudentMgmtSystem.Controllers
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

        [HttpPost("generate-otp")]
        public async Task<IActionResult> GenerateOtp([FromBody] OtpRequest req)
        {
            var otp = await _authService.GenerateOtp(req);
            return Ok(new { otp });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var result = await _authService.Register(req);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = result.Message });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var result = await _authService.Login(req);

            if (!result.Success)
            {
                return Unauthorized(new { message = result.Token }); // Here result.Token contains the error message
            }

            // Return only the token
            return Ok(new { token = result.Token });
        }
    }
}
