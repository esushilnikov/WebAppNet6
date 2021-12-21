using Domain.Entities;

namespace Application.Constants.Persistence;

public interface IUserRepository : IAsyncRepository<UserAccount>
{
    Task<UserAccount?> GetUserAccountAsync(string email);
}