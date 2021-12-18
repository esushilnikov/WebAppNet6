using Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [Authorize]
    [Route("")]
    public async Task<IActionResult> GetUser()
    {
        return Ok(await _userRepository.GetUserAsync(User.Identity.Name, ""));
    }
    
    [Authorize]
    [Route("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userRepository.GetAllAsync());
    }
    
}