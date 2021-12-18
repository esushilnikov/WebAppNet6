using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TwitterApp.Models;
using WebApp.API.Models;

namespace WebApp.API.Controllers;

[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost("sign-up")]
    public IActionResult SignUp([FromBody] SignUpModel model)
    {
        return Ok("Scc cscsa");
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInModel model)
    {
        var identity = await GetIdentityAsync(model.UserName, model.Password);
        if (identity == null)
        {
            return BadRequest(new { errorText = "Invalid username or password." });
        }

        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return Json(encodedJwt);
    }

    private async Task<ClaimsIdentity> GetIdentityAsync(string username, string password)
    {
        var user = await _userRepository.GetUserAsync(username, password);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                //new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", 
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        return null;
    }
}
