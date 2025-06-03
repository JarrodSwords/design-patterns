using System.Data.Common;
using DesignPatterns.Builder3.Infrastructure.Write;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Builder3.Spec;

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
