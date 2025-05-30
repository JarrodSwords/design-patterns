namespace DesignPatterns.Builder3.Infrastructure.Write;

public class Message
{
    public Message()
    {
    }

    public Message(
        uint id,
        uint? parentId,
        uint postId,
        uint userId,
        string text,
        DateTime timestamp
    )
    {
        Id = id;
        ParentId = parentId;
        PostId = postId;
        UserId = userId;
        Text = text;
        Timestamp = timestamp;
    }

    public uint Id { get; set; }
    public uint? ParentId { get; set; }
    public uint PostId { get; set; }
    public uint UserId { get; set; }
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }

    public static implicit operator Domain.Message(Message source) =>
        new(
            source.Id,
            source.PostId,
            source.UserId,
            source.Text,
            source.Timestamp,
            source.ParentId
        );

    public static implicit operator Message(Domain.Message source) =>
        new(
            source.Id,
            null,
            source.PostId,
            source.UserId,
            source.Text,
            source.Timestamp
        );
}
