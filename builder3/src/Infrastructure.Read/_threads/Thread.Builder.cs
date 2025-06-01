using DesignPatterns.Builder3.Infrastructure.Read.Database;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public partial class Thread
{
    public class Builder : IMessageBuilder
    {
        private readonly Thread _thread;

        public Thread GetThread() => _thread;

        public Message Add(Database.Message message, User user) => throw new NotImplementedException();
    }
}
