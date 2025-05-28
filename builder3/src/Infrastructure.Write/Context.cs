using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Builder3.Infrastructure.Write;

public class Context : DbContext
{
    public DbSet<Message> Message { get; set; }
    public DbSet<User> User { get; set; }
}
