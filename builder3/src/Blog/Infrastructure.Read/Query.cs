using Jgs.Errors;
using Jgs.Errors.Results;
using Microsoft.Data.SqlClient;

namespace DesignPatterns.Builder3.Blog.Infrastructure.Read;

public abstract class Query<T> where T : Args
{
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

    public abstract Result ExecuteQuery(SqlConnection connection, T args);

    public virtual Error HandleException(Exception e) => new("Not found", e.Message);
}

public abstract class Query<TArgs, TResponse> where TArgs : Args
{
    public abstract Result<TResponse> Execute(TArgs args);
}

public abstract record Args;
