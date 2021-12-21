using Application.Constants.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : BaseRepository<UserAccount>, IUserRepository
{
    private readonly WebAppDbContext _context;
    
    public UserRepository(WebAppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UserAccount?> GetUserAccountAsync(string email)
    {
        return await _context.UserAccounts.FirstOrDefaultAsync(x => x.Email == email);
    }
}