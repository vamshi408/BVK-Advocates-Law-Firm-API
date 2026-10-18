using BVK_Advocates_Law_Firm.Models;
using BVK_Advocates_Law_Firm.Services;
using Microsoft.AspNetCore.Mvc;

namespace BVK_Advocates_Law_Firm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthController(ITokenService tokenService, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _configuration = configuration;
        }

        /// <summary>
        /// Demo login endpoint. Replace with your user store validation.
        /// POST /api/auth/login
        /// Body: { "username": "admin", "password": "password" }
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Username and password required.");

            var demoUser = _configuration["DemoUser:Username"] ?? "admin";
            var demoPassword = _configuration["DemoUser:Password"] ?? "password";

            if (request.Username != demoUser || request.Password != demoPassword)
                return Unauthorized("Invalid credentials.");

            var token = _tokenService.GenerateToken(request.Username);

            var expiresIn = int.TryParse(_configuration.GetSection("Jwt")["DurationInMinutes"], out var m) ? m : 60;

            var response = new AuthResponse
            {
                Token = token,
                ExpiresInMinutes = expiresIn
            };

            return Ok(response);
        }
    }
}