using Jgs.Errors;
using Jgs.Errors.Results;
using Microsoft.Data.SqlClient;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public interface IQuery;

public interface IQueryHandler<in T> where T : IQuery
{
    Result Execute(T args);
}

public abstract class QueryHandler<T> : IQueryHandler<T> where T : IQuery
{
    protected abstract Result ExecuteQuery(SqlConnection connection, T query);
    protected virtual Error HandleException(Exception e) => new("Not found", e.Message);

    public Result Execute(T args)
    {
        try
        {
            using var connection = new SqlConnection();
            connection.Open();

            return ExecuteQuery(connection, args);
        }
        catch (Exception e)
        {
            return HandleException(e);
        }
    }
}

public abstract class QueryHandler<TArgs, TResponse> where TArgs : IQuery
{
    public abstract Result<TResponse> Execute(TArgs args);
}
