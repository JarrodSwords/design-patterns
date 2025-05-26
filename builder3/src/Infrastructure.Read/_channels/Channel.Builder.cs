namespace DesignPatterns.Builder3.Infrastructure.Read;

public partial class Channel
{
    public class Builder : IDiscussionBuilder
    {
        private readonly Channel _channel = new();
        private readonly Dictionary<uint, Message> _messages = new();

        public Message Add(Database.Message m, Database.User u) =>
            Message.From(m, u)
                .Then(
                    message =>
                    {
                        if (_messages.TryAdd(message.Id, message))
                            _channel.Add(message);

                        return message;
                    }
                );

        public Channel GetChannel() => _channel;
    }
}
