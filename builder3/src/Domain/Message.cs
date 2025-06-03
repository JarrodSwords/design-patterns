namespace DesignPatterns.Builder3.Domain;

public class Message(
    MessageId id,
    ContextId contextId,
    UserId userId,
    string text,
    DateTime timestamp,
    MessageId? parentId = null
)
{
    public MessageId Id { get; } = id;
    public ContextId ContextId { get; } = contextId;
    public MessageId? ParentId { get; } = parentId;
    public UserId UserId { get; } = userId;
    public string Text { get; } = text;
    public DateTime Timestamp { get; } = timestamp;
}
