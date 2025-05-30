namespace DesignPatterns.Builder3.Domain;

public class Message(
    MessageId id,
    PostId postId,
    UserId userId,
    string text,
    DateTime timestamp,
    MessageId? parentId = null
)
{
    public MessageId Id { get; } = id;
    public MessageId? ParentId { get; } = parentId;
    public PostId PostId { get; } = postId;
    public UserId UserId { get; } = userId;
    public string Text { get; } = text;
    public DateTime Timestamp { get; } = timestamp;
}
