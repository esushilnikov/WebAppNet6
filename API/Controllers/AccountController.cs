using Application.Identity;
using Application.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.API.Controllers;

[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly IWebAppAuthenticationService _webAppAuthenticationService;

    public AccountController(IWebAppAuthenticationService webAppAuthenticationService)
    {
        _webAppAuthenticationService = webAppAuthenticationService;
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync([FromBody] AuthenticationRequest request)
    {
        return Ok(await _webAppAuthenticationService.AuthenticateAsync(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> RegisterAsync([FromBody] RegistrationRequest request)
    {
        return Ok(await _webAppAuthenticationService.RegisterAsync(request));
    }
}