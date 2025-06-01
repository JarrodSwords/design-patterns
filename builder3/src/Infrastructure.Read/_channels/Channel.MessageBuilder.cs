namespace DesignPatterns.Builder3.Infrastructure.Read;

public partial class Channel : IMessageBuilder
{
    public object Add(Database.Message message, Database.User user) =>
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
