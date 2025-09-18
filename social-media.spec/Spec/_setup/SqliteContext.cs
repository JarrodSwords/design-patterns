using System.Data.Common;
using Dapper;
using Examples.SocialMedia.Domain;
using Examples.SocialMedia.Infrastructure.Write;
using Microsoft.Data.Sqlite;
using Message = Examples.SocialMedia.Domain.Message;
using User = Examples.SocialMedia.Infrastructure.Write.User;

namespace Examples.SocialMedia.Spec;

public class SqliteContext : IConnectionProvider, IDisposable
{
    private readonly DbConnection _connection;
    private readonly Context _context;

    public SqliteContext()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        _context = DbContextFactory.CreateContext(_connection);

        Seed(ObjectProvider.GetUsers());
        Seed(ObjectProvider.GetMessages());
    }

    public void Seed(IEnumerable<Message> messages)
    {
        var repository = new MessageRepository(_context);

        foreach (var message in messages)
            repository.Create(message);

        _context.SaveChanges();
    }

    public void Seed(IEnumerable<User> users)
    {
        foreach (var user in users)
            _connection.Execute("INSERT INTO User (Id, Name) VALUES (@Id, @Name)", user);
    }

    public DbConnection GetConnection() => _connection;

    public void Dispose()
    {
        _connection.Dispose();

        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}

[CollectionDefinition("sqlite")]
public class SqliteCollection : ICollectionFixture<SqliteContext>
{
}
