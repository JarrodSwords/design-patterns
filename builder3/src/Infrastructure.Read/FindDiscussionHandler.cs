using System.Data.Common;
using Dapper;
using DesignPatterns.Builder3.Domain;
using DesignPatterns.Builder3.Infrastructure.Read.Database;
using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public class FindDiscussionHandler(IConnectionProvider connectionProvider)
    : QueryHandler<FindDiscussion>(connectionProvider)
{
    private const string Query =
        """
        SELECT M.*
             , U.*
          FROM Message M
          JOIN User U
            ON U.Id = M.UserId
         WHERE ContextId = @ContextId
         ORDER BY Timestamp
        """;

    protected override Result ExecuteQuery(DbConnection connection, FindDiscussion query)
    {
        var (args, builder) = query;

        connection.Query<Database.Message, User, Message>(
            Query,
            builder.Add,
            args,
            splitOn: "Id"
        );

        return Success();
    }
}

public class FindDiscussion(uint contextId, IDiscussionBuilder builder) : IQuery
{
    public void Deconstruct(out object args, out IDiscussionBuilder builder)
    {
        args = new { ContextId };
        builder = Builder;
    }

    public uint ContextId { get; } = contextId;
    public IDiscussionBuilder Builder { get; } = builder;
}
