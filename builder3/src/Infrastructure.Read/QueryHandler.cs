using System.Data;
using System.Data.Common;
using DesignPatterns.Builder3.Domain;
using Jgs.Errors;
using Jgs.Errors.Results;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public interface IQuery;

public interface IQueryHandler<in T> where T : IQuery
{
    Result Execute(T args);
}

public abstract class QueryHandler<T> : IQueryHandler<T> where T : IQuery
{
    private readonly IConnectionProvider _connectionProvider;

    protected QueryHandler(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    protected abstract Result ExecuteQuery(DbConnection connection, T query);
    protected virtual Error HandleException(Exception e) => new("Not found", e.Message);

    public Result Execute(T args)
    {
        var shouldClose = false;

        try
        {
            var connection = _connectionProvider.GetConnection();

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                shouldClose = true;
            }

            var result = ExecuteQuery(connection, args);

            if (shouldClose)
                connection.Close();

            return result;
        }
        catch (Exception e)
        {
            return HandleException(e);
        }
    }
}
