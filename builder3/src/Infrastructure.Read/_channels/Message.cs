using DesignPatterns.Builder3.Infrastructure.Read.Database;
using Jgs.Errors.Results;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public class Message : IComparable<Message>
{
    private Message(
        uint id,
        uint channelId,
        uint? parentId,
        string text,
        DateTime timestamp,
        User user
    )
    {
        Id = id;
        ChannelId = channelId;
        ParentId = parentId;
        Text = text;
        Timestamp = timestamp;
        User = user;
    }

    public static Result<Message> From(Database.Message message, User user) =>
        new Message(
            message.Id,
            message.PostId,
            message.ParentId,
            message.Text,
            message.Timestamp,
            user
        );

    public uint Id { get; }
    public uint ChannelId { get; }
    public uint? ParentId { get; }
    public string Text { get; }
    public DateTime Timestamp { get; }
    public User User { get; }

    public int CompareTo(Message? other) => Timestamp.CompareTo(other.Timestamp);
}
