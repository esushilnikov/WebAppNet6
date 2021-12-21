using System.Security.Claims;
using Application.Constants.Persistence;

namespace WebApp.API.Middleware;

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
            // TODO: use cache to restore user state
            context.Items["UserState"] =
                await userRepository.GetUserAccountAsync(emailClaimValue);
        }

        await _next(context);
    }
}