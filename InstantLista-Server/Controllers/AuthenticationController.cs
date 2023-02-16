using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InstantLista_ClassLibrary;
using InsantLista_Services.Interfaces;

namespace InstantLista_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IAuthenticationService _authenticationSerivce;

    public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
    {
        _logger = logger;
        _authenticationSerivce = authenticationService;
    }

    [HttpPost("login",Name = "GetJWT")]
    [AllowAnonymous]
    public async Task<TokenJWTDto> GetJWT([FromBody] UserAuthenticationDto userAuthenticationDto)
    {
        return await _authenticationSerivce.Authenticate(userAuthenticationDto.Email, userAuthenticationDto.Password);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="refreshModel"></param>
    /// <returns></returns>
    [HttpPost("refresh", Name = "GetRefreshedJWT")]
    [AllowAnonymous]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public async Task<TokenJWTDto> GetJWT([FromBody] TokenRefreshDto refreshModel)
    {
        var bearerToken = Request.Headers["Authorization"].ToString().Split()[1];


        return await _authenticationSerivce.Refresh(bearerToken, refreshModel.idToken);
    }
}

