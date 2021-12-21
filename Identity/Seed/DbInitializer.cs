using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seed;

public static class DbIdentityInitializer
{
    public static async Task InitializeUsersAsync(WebAppIdentityDbContext context, UserManager<ApplicationUser> userManager)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.Users.Any())
        {
            var applicationUsers = new List<ApplicationUser>
            {
                new()
                {
                    UserName = "john.doe",
                    Email = "john.doe@mail.ua",
                    EmailConfirmed = true
                },
                new()
                {
                    UserName = "garry.lehman",
                    Email = "garry.lehman@mail.ua",
                    EmailConfirmed = true
                },
                new()
                {
                    UserName = "jeff.smith",
                    Email = "jeff.smith@mail.ua",
                    EmailConfirmed = true
                }
            };

            foreach (var applicationUser in applicationUsers)
            {
                await userManager.CreateAsync(applicationUser, "Qwerty!23456");
            }
        }
    }
}