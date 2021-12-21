using Application.Features.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : WebAppBaseController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Authorize]
    [Route("")]
    public async Task<IActionResult> GetCurrentUser()
    {
        return Ok(await _mediator.Send(new GetUserQuery { UserId = UserAccount.Id }));
    }

    [Authorize]
    [Route("get-user")]
    public async Task<IActionResult> GetUser(int userId)
    {
        return Ok(await _mediator.Send(new GetUserQuery { UserId = userId }));
    }
}