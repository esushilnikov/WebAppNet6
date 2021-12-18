using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<ApplicationUser?> GetUserAsync(string id);
    Task<ApplicationUser?> GetUserAsync(string userName, string password);
    Task<IEnumerable<ApplicationUser>> GetAllAsync();
}

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApplicationUser?> GetUserAsync(string id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ApplicationUser?> GetUserAsync(string userName, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
}