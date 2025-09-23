using Jgs.Errors;

namespace Examples.SocialMedia.Infrastructure.Read;

public interface IMessageBuilder
{
    Result Add(Database.Message message, Database.User user);
}
