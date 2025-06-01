namespace DesignPatterns.Builder3.Infrastructure.Read;

public interface IMessageBuilder
{
    object Add(Database.Message message, Database.User user);
}
