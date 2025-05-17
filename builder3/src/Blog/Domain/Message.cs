namespace DesignPatterns.Builder3.Blog.Domain;

public class Message(
    MessageId id,
    UserId userId,
    string text,
    DateTime timestamp,
    Message? parent = null
)
{
    public MessageId Id { get; } = id;
    public UserId UserId { get; } = userId;
    public Message? Parent { get; } = parent;
    public string Text { get; } = text;
    public DateTime Timestamp { get; } = timestamp;
}
