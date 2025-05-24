namespace DesignPatterns.Builder3.Blog.Infrastructure.Read;

public interface IDiscussionBuilder
{
    //IDiscussionBuilder Add(Database.Message record);
    Message Add(Database.Message m, Database.User u);
}
