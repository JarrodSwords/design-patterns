using System.Data.Common;
using DesignPatterns.Builder3.Domain;
using DesignPatterns.Builder3.Infrastructure.Write;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Builder3.Spec;

public class SqliteContext : IConnectionProvider, IDisposable
{
    private readonly DbConnection _connection;
    private readonly Context _context;

    public SqliteContext()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        _context = DbContextFactory.CreateContext(_connection);
    }

    public Context GetContext() => _context;
    public DbConnection GetConnection() => _connection;

    public void Dispose()
    {
        _connection.Dispose();
        _context.Dispose();
    }
}

[CollectionDefinition("sqlite")]
public class SqliteCollection : ICollectionFixture<SqliteContext>
{
}

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
