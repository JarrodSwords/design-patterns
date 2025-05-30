using static DesignPatterns.Builder3.Domain.ICommentBuilder;

namespace DesignPatterns.Builder3.Domain;

public partial class Chat
{
    public class Builder : ICommentBuilder
    {
        private readonly Dictionary<MessageId, Message> _messages = new();
        private Chat? _chat;

        public Chat GetChat() => _chat!;

        public ICommentBuilder Add(CommentArgs args)
        {
            var (id, parentId, postId, userId, text, timestamp) = args;

            _chat ??= new(postId);

            var message = parentId is null
                ? new Message(id, postId, userId, text, timestamp)
                : new Message(id, postId, userId, text, timestamp, parentId);

            _messages.TryAdd(message.Id, message);

            _chat.Add(message);

            return this;
        }
    }
}
