using Jgs.Errors;

namespace Examples.SocialMedia.Domain;

public interface IMessageRepository
{
    Result Create(Message message);
    Result<Message> Find(MessageId id);
}
