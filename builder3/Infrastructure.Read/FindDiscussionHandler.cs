using System.Data.Common;
using Dapper;
using Examples.SocialMedia.Domain;
using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace Examples.SocialMedia.Infrastructure.Read;

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

        connection.Query<Database.Message, Database.User, object>(
            Query,
            builder.Add,
            args,
            splitOn: "Id"
        );

        return Success();
    }
}

public class FindDiscussion(uint contextId, IMessageBuilder builder) : IQuery
{
    public void Deconstruct(out object args, out IMessageBuilder builder)
    {
        args = new { ContextId };
        builder = Builder;
    }

    public uint ContextId { get; } = contextId;
    public IMessageBuilder Builder { get; } = builder;
}
