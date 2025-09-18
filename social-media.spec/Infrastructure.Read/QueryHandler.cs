using System.Data;
using System.Data.Common;
using Examples.SocialMedia.Domain;
using Jgs.Errors;
using Jgs.Errors.Results;

namespace Examples.SocialMedia.Infrastructure.Read;

public interface IQuery;

public interface IQueryHandler<in T> where T : IQuery
{
    Result Execute(T args);
}

public abstract class QueryHandler<T>(IConnectionProvider connectionProvider)
    : IQueryHandler<T> where T : IQuery
{
    protected abstract Result ExecuteQuery(DbConnection connection, T query);
    protected virtual Error HandleException(Exception e) => new("Not found", e.Message);

    public Result Execute(T args)
    {
        var shouldClose = false;
        var connection = connectionProvider.GetConnection();

        try
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                shouldClose = true;
            }

            return ExecuteQuery(connection, args);
        }
        catch (Exception e)
        {
            return HandleException(e);
        }
        finally
        {
            if (shouldClose)
                connection.Close();
        }
    }
}
