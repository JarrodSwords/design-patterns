using DesignPatterns.Builder3.Domain;
using Jgs.Errors;
using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace DesignPatterns.Builder3.Infrastructure.Write;

public class MessageRepository(Context context) : IMessageRepository
{
    public Result Create(Domain.Message message)
    {
        if (context.Message.Any(x => x.Id == message.Id))
            return MessageAlreadyExists(message.Id);

        context.Message.Add(message);

        return Success();
    }

    public Result<Domain.Message> Find(MessageId messageId)
    {
        var message = context.Message.SingleOrDefault(x => x.Id == messageId);

        return message is null
            ? NotFound(messageId)
            : (Domain.Message) message;
    }

    private static Error MessageAlreadyExists(uint id) =>
        new(
            "message.already.exists",
            $"Message {id} already exists."
        );

    private static Error NotFound(uint id) => new("not.found", $"Message {id} not found.");
}
