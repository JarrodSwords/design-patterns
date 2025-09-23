using System.Data.Common;
using System.Linq.Expressions;
using Dapper;
using Examples.SocialMedia.Domain;
using Jgs.Errors;
using static Jgs.Errors.Result;

namespace Examples.SocialMedia.Infrastructure.Read;

public class FindDiscussionHandler(IConnectionProvider connectionProvider)
    : QueryHandler<FindDiscussion>(connectionProvider)
{
    protected override Result ExecuteQuery(DbConnection connection, FindDiscussion query)
    {
        var (args, builder, spec) = query;
        var sql = $"""
                   SELECT M.*
                        , U.*
                     FROM Message M
                     JOIN User U
                       ON U.Id = M.UserId
                    WHERE {spec.GetSql()}
                    ORDER BY Timestamp
                   """;

        connection.Query<Database.Message, Database.User, Result>(
            sql,
            builder.Add,
            args,
            splitOn: "Id"
        );

        return Success();
    }
}

public class FindDiscussion : IQuery
{
    private readonly Specification<Message> _spec;

    public FindDiscussion(IMessageBuilder builder, Specification<Message> spec)
    {
        _spec = spec;
        Builder = builder;
    }

    public void Deconstruct(out object args, out IMessageBuilder builder, out Specification<Message> spec)
    {
        builder = Builder;
        spec = _spec;
        args = spec.GetArgs();
    }

    public IMessageBuilder Builder { get; }
}

public abstract class Specification<T>
{
    public abstract object GetArgs();
    public abstract string GetSql();

    public bool IsSatisfiedBy(T value) => ToExpression().Compile()(value);

    protected abstract Expression<Func<T, bool>> ToExpression();
}

public class InContext(uint contextId) : Specification<Message>
{
    public override object GetArgs() => new { ContextId = contextId };

    public override string GetSql() => "M.[ContextId] = @ContextId";

    protected override Expression<Func<Message, bool>> ToExpression() => message => message.ChannelId == contextId;
}
