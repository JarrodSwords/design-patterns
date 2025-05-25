using DesignPatterns.Builder3.Infrastructure.Read._channels;
using User = DesignPatterns.Builder3.Infrastructure.Read.Database.User;

namespace DesignPatterns.Builder3.Infrastructure.Read._threads;

public partial class Thread
{
    public class Builder : IDiscussionBuilder
    {
        private readonly Thread _thread;

        public Thread GetThread() => _thread;

        public Message Add(Database.Message m, User u) => throw new NotImplementedException();
    }
}
