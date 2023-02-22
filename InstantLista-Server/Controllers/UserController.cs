using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InstantLista_ClassLibrary;
using InsantLista_Services.Interfaces;

namespace InstantLista_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet("get-user-profile",Name = "GetUserById")]
    public async Task<ActionResult<UserDto>> GetUserById(int userNumber)
    {
        var result = await _userService.GetUser(userNumber);

        return result != null ? result: NotFound();
    }

    
}

