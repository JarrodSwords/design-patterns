using DesignPatterns.Builder3.Infrastructure.Read.Database;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public interface IMessageBuilder
{
    Message Add(Database.Message message, User user);
}
