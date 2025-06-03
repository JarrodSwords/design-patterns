using System.Data.Common;
using Examples.SocialMedia.Infrastructure.Write;
using Microsoft.EntityFrameworkCore;

namespace Examples.SocialMedia.Spec;

public class DbContextFactory
{
    public static Context CreateContext(DbConnection connection)
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseSqlite(connection)
            .Options;

        var context = new Context(options);

        context.Database.EnsureCreated();

        return context;
    }
}
