using System.Data.Common;
using DesignPatterns.Builder3.Domain;
using Microsoft.Data.Sqlite;

namespace DesignPatterns.Builder3.Spec;

public class DatabaseContext : IConnectionProvider, IDisposable
{
    private readonly DbConnection _connection;

    public DatabaseContext()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
    }

    public DbConnection GetConnection() => _connection;

    public void Dispose()
    {
        _connection.Dispose();
    }
}

[CollectionDefinition("database")]
public class DatabaseCollection : ICollectionFixture<DatabaseContext>
{
}
