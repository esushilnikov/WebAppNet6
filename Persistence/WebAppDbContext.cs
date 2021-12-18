using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class WebAppDbContext: DbContext
{
    public WebAppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserAccount> UserAccounts { get; set; }
}