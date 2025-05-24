using Dapper;
using Jgs.Errors.Results;
using Microsoft.Data.SqlClient;
using static Jgs.Errors.Results.Result;

namespace DesignPatterns.Builder3.Blog.Infrastructure.Read;

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

    protected override Result ExecuteQuery(SqlConnection connection, FindDiscussion query)
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
