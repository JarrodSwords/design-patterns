namespace DesignPatterns.Builder3.Blog.Infrastructure.Read;

public partial class Thread
{
    public class Builder : IDiscussionBuilder
    {
        private readonly Thread _thread;

        public Thread GetThread() => _thread;

        public Message Add(Database.Message m, Database.User u) => throw new NotImplementedException();
    }
}
