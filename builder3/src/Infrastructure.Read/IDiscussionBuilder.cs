using DesignPatterns.Builder3.Infrastructure.Read._channels;
using User = DesignPatterns.Builder3.Infrastructure.Read.Database.User;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public interface IDiscussionBuilder
{
    //IDiscussionBuilder Add(Database.Message record);
    Message Add(Database.Message m, User u);
}
