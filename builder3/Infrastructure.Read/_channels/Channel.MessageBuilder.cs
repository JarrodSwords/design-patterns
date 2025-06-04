using Jgs.Errors.Results;

namespace Examples.SocialMedia.Infrastructure.Read;

public partial class Channel : IMessageBuilder
{
    public Result Add(Database.Message message, Database.User user) =>
        Message.From(message, user)
            .Then(
                m =>
                {
                    if (!_messages.ContainsValue(m))
                        _messages.Add(m.Timestamp, m);
                }
            );
}
