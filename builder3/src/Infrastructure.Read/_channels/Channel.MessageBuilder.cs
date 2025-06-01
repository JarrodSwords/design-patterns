using DesignPatterns.Builder3.Infrastructure.Read.Database;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public partial class Channel : IMessageBuilder
{
    public Message Add(Database.Message message, User user) =>
        Message.From(message, user)
            .Then(
                m =>
                {
                    if (!_messages.ContainsValue(m))
                        _messages.Add(m.Timestamp, m);

                    return m;
                }
            );
}
