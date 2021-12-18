using Application.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WebAppDbContext _context;
    
    public UserRepository(WebAppDbContext context)
    {
        _context = context;
    }

    public async Task<UserAccount?> GetUserAsync(string id)
    {
        return await _context.UserAccounts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserAccount?> GetUserAsync(string userName, string password)
    {
        return await _context.UserAccounts.FirstOrDefaultAsync(x => x.UserName == userName || x.Email == userName);
    }

    public async Task<IEnumerable<UserAccount>> GetAllAsync()
    {
        return await _context.UserAccounts.ToListAsync();
    }
}