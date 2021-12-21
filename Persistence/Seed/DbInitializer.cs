using Application.Constants.Persistence;
using Domain.Entities;

namespace Persistence.Seed;

public static class DbInitializer
{
    public static async Task InitializeUserAccountsAsync(WebAppDbContext context, IUserRepository userRepository)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.UserAccounts.Any())
        {
            var userAccounts = new List<UserAccount>
            {
                new()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "john.doe",
                    Email = "john.doe@mail.ua",
                },
                new()
                {
                    FirstName = "Garry",
                    LastName = "Lehman",
                    UserName = "garry.lehman",
                    Email = "garry.lehman@mail.ua",
                },
                new()
                {
                    FirstName = "Jeff",
                    LastName = "Smith",
                    UserName = "jeff.smith",
                    Email = "jeff.smith@mail.ua",
                }
            };

            foreach (var userAccount in userAccounts)
            {
                await userRepository.AddAsync(userAccount);
            }
        }
    }
}