using Jgs.Errors.Results;

namespace DesignPatterns.Builder3.Domain;

public interface IMessageRepository
{
    Result Create(Message message);
    Result<Message> Find(MessageId messageId);
}
