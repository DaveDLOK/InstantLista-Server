using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InstantLista_Server.Models;

namespace InstantLista_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger;
    }

    [HttpPost("login",Name = "GetJWT")]
    [AllowAnonymous]
    public async Task GetJWT([FromBody] UserAuthenticationModel userAuthenticationModel)
    {
        
    }
}

