namespace DesignPatterns.Builder3.Infrastructure.Read;

public partial class Thread
{
    public class Builder : IDiscussionBuilder
    {
        private readonly Thread _thread;

        public Message Add(Database.Message m, Database.User u) => throw new NotImplementedException();

        public Thread GetThread() => _thread;
    }
}
