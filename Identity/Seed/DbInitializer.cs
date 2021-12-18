using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seed;

public static class DbInitializer
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
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "john.doe",
                    Email = "john.doe@mail.ua",
                    EmailConfirmed = true
                },
                new()
                {
                    FirstName = "Garry",
                    LastName = "Lehman",
                    UserName = "garry.lehman",
                    Email = "garry.lehman@mail.ua",
                    EmailConfirmed = true
                },
                new()
                {
                    FirstName = "Jeff",
                    LastName = "Smith",
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