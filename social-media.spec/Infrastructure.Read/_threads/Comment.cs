using System.Diagnostics;

namespace Examples.SocialMedia.Infrastructure.Read;

[DebuggerDisplay("{GetDebugString()}")]
public partial class Comment : IComparable<Comment>
{
    public uint Id { get; }
    public IReadOnlyList<Comment> Children => _children;
    public string Text { get; }
    public DateTime Timestamp { get; }
    public User User { get; }

    public string GetDebugString() => @$"""{Text}"" ~{User.Name}";

    public int CompareTo(Comment? other) => Timestamp.CompareTo(other.Timestamp);
}
