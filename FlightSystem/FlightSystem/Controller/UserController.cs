using Microsoft.AspNetCore.Mvc;
using UserApiWithSQLite.Services;
using FlightSystem.Models;

namespace UserApiWithSQLite.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user-list")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpGet("user-info/{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost("user-add")]
        public async Task<ActionResult<User>> CreateUser(User dto)
        {
            var result = await _userService.CreateUserAsync(dto);
            if (!result.Success)
                return StatusCode(result.StatusCode, result.Message);
            return CreatedAtAction(nameof(GetUser), new { id = result.Data!.Id }, result.Data);
        }

        [HttpPost("user-update")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var result = await _userService.UpdateUserAsync(user);
            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpDelete("user-delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
