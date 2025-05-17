using Dapper;
using Jgs.Errors.Results;
using Microsoft.Data.SqlClient;
using static Jgs.Errors.Results.Result;

namespace DesignPatterns.Builder3.Blog.Infrastructure.Read;

public class FindConversation : Query<FindConversationArgs>
{
    private const string Query =
        """
        SELECT * 
          FROM Comment 
         WHERE RootId = @rootId
         ORDER BY Timestamp
        """;

    public override Result ExecuteQuery(SqlConnection connection, FindConversationArgs args)
    {
        var (rootId, builder) = args;

        var comments = connection.Query<Database.Comment>(Query, new { rootId });

        foreach (var comment in comments)
            builder.Add(comment);

        return Success();
    }
}

public record FindConversationArgs(uint RootId, ICommentBuilder Builder) : Args;
