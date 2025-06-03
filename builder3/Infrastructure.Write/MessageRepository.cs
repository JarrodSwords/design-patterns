using Examples.SocialMedia.Domain;
using Jgs.Errors;
using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace Examples.SocialMedia.Infrastructure.Write;

public class MessageRepository(Context context) : IMessageRepository
{
    public Result Create(Domain.Message message)
    {
        if (context.Message.Any(x => x.Id == message.Id))
            return MessageAlreadyExists(message.Id);

        context.Message.Add(message);

        return Success();
    }

    public Result<Domain.Message> Find(MessageId id)
    {
        var message = context.Message.SingleOrDefault(x => x.Id == id);

        return message is null
            ? NotFound(id)
            : (Domain.Message) message;
    }

    private static Error MessageAlreadyExists(uint id) =>
        new(
            "message.already.exists",
            $"Message {id} already exists."
        );

    private static Error NotFound(uint id) => new("not.found", $"Message {id} not found.");
}
