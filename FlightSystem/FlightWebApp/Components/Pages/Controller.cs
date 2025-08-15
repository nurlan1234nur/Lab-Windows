using Microsoft.AspNetCore.Mvc;
using FlightSystem.Models;
using UserApiWithSQLite.Services;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await _userService.GetUsersAsync();
    }
}
