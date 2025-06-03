namespace Examples.SocialMedia.Infrastructure.Write;

public class Message
{
    public Message()
    {
    }

    public Message(
        uint id,
        uint contextId,
        uint userId,
        string text,
        DateTime timestamp,
        uint? parentId = null
    )
    {
        Id = id;
        ContextId = contextId;
        ParentId = parentId;
        UserId = userId;
        Text = text;
        Timestamp = timestamp;
    }

    public uint Id { get; set; }
    public uint ContextId { get; set; }
    public uint? ParentId { get; set; }
    public uint UserId { get; set; }
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }

    public static implicit operator Domain.Message(Message source) =>
        new(
            source.Id,
            source.ContextId,
            source.UserId,
            source.Text,
            source.Timestamp,
            source.ParentId
        );

    public static implicit operator Message(Domain.Message source) =>
        new(
            source.Id,
            source.ContextId,
            source.UserId,
            source.Text,
            source.Timestamp,
            source.ParentId?.Value
        );
}
