using System.Data.Common;

namespace Examples.SocialMedia.Domain;

public interface IConnectionProvider
{
    DbConnection GetConnection();
}
