namespace DesignPatterns.Builder3.Infrastructure.Read;

public interface IDiscussionBuilder
{
    Message Add(Database.Message m, Database.User u);
}
