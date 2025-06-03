using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Builder3.Infrastructure.Write;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Message> Message { get; set; }
    public DbSet<User> User { get; set; }
}
