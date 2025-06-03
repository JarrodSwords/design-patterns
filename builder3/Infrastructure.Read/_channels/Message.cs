using System.Diagnostics;
using Jgs.Errors.Results;

namespace Examples.SocialMedia.Infrastructure.Read;

[DebuggerDisplay("{GetDebugString()}")]
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

    public static Result<Message> From(Database.Message message, Database.User user) =>
        new Message(
            message.Id,
            message.ContextId,
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
    public string GetDebugString() => @$"{User.Name}: ""{Text}""";

    public int CompareTo(Message? other) => Timestamp.CompareTo(other.Timestamp);
}
