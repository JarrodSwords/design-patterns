using static DesignPatterns.Builder3.Domain.ICommentBuilder;

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
        uint rootId,
        uint userId,
        string text,
        DateTime timestamp
    )
    {
        Id = id;
        ParentId = parentId;
        PostId = postId;
        RootId = rootId;
        UserId = userId;
        Text = text;
        Timestamp = timestamp;
    }

    public uint Id { get; set; }
    public uint? ParentId { get; set; }
    public uint PostId { get; set; }
    public uint RootId { get; set; }
    public uint UserId { get; set; }
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }

    public static implicit operator CommentArgs(Message source) =>
        new(
            source.Id,
            source.ParentId,
            source.PostId,
            source.UserId,
            source.Text,
            source.Timestamp
        );
}
