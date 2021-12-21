using System.Security.Claims;
using Application.Constants.Persistence;
using Microsoft.AspNetCore.Http;

namespace Persistence.MiddleWares;

public class UserStateInitializer
{
    private readonly RequestDelegate _next;

    public UserStateInitializer(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserRepository userRepository)
    {
        var emailClaimValue = context.User.FindFirstValue(ClaimTypes.Email);
        if (!string.IsNullOrEmpty(emailClaimValue))
        {
            context.Items["UserAccount"] =
                await userRepository.GetUserAccountAsync(emailClaimValue);
        }

        await _next(context);
    }
}