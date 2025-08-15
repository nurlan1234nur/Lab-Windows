using Microsoft.AspNetCore.Mvc;
using FlightSystem.Models;
using FlighSystemLib.Service;

namespace FlightApiWithSQLite.Controllers
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Имэйл болон нууц үг хоосон байж болохгүй.");

            var user = await _authService.AuthenticateAsync(dto.Email, dto.Password);
            if (user == null)
                return Unauthorized("Имэйл эсвэл нууц үг буруу байна.");

            // Амжилттай нэвтэрсэн мэдээллийг буцаах
            var response = new
            {
                message = "Амжилттай нэвтэрлээ",
                user.Id,
                user.FirstName,
                user.Role
            };

            return Ok(response);
        }
    }
}
