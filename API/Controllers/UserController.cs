using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    public UserController()
    {
    }
    
    /*[Authorize]
    [Route("")]
    public async Task<IActionResult> GetUser()
    {
    }
    
    [Authorize]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
    }*/
    
}