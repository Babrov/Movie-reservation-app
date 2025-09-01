using Microsoft.EntityFrameworkCore;

namespace AuthService;

public class AuthDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
}