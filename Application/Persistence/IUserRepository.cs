using Domain.Entities;

namespace Application.Persistence;

public interface IUserRepository
{
    Task<UserAccount?> GetUserAsync(string id);
    Task<UserAccount?> GetUserAsync(string userName, string password);
    Task<IEnumerable<UserAccount>> GetAllAsync();
}