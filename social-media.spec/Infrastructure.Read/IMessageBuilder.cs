using Jgs.Errors.Results;

namespace Examples.SocialMedia.Infrastructure.Read;

public interface IMessageBuilder
{
    Result Add(Database.Message message, Database.User user);
}
