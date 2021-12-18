using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity;

public class WebAppIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public WebAppIdentityDbContext(DbContextOptions<WebAppIdentityDbContext> options) : base(options)
    {
    }
}