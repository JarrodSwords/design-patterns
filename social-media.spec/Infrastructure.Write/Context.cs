using Microsoft.EntityFrameworkCore;

namespace Examples.SocialMedia.Infrastructure.Write;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Message> Message { get; set; }
    public DbSet<User> User { get; set; }
}
