using System.Data.Common;
using Dapper;
using DesignPatterns.Builder3.Domain;
using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public class FindDiscussionHandler : QueryHandler<FindDiscussion>
{
    private const string Query =
        """
        SELECT M.*
             , D.*
          FROM Message M
          JOIN User U
            ON U.Id = M.UserId
         WHERE RootId = @rootId
         ORDER BY Timestamp
        """;

    private readonly IMessageRepository _messageRepository;

    public FindDiscussionHandler(IConnectionProvider connectionProvider, IMessageRepository messageRepository) : base(
        connectionProvider
    )
    {
        _messageRepository = messageRepository;
    }

    protected override Result ExecuteQuery(DbConnection connection, FindDiscussion query)
    {
        var (args, builder) = query;

        connection.Query<Database.Message, Database.User, Message>(
            Query,
            builder.Add,
            args,
            splitOn: "Id"
        );

        return Success();
    }
}

public class FindDiscussion(uint rootId, IDiscussionBuilder builder) : IQuery
{
    public void Deconstruct(out object args, out IDiscussionBuilder builder)
    {
        args = new { RootId };
        builder = Builder;
    }

    public uint RootId { get; } = rootId;
    public IDiscussionBuilder Builder { get; } = builder;
}
