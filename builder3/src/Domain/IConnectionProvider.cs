using System.Data.Common;

namespace DesignPatterns.Builder3.Domain;

public interface IConnectionProvider
{
    DbConnection GetConnection();
}
