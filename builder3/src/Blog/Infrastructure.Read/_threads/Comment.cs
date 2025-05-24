namespace DesignPatterns.Builder3.Blog.Infrastructure.Read;

public partial class Comment
{
    private readonly List<Comment> _children = [];

    public uint Id { get; }
    public uint UserId { get; }
    public IReadOnlyList<Comment> Children => _children;
    public string Text { get; }
    public DateTime Timestamp { get; }

    private Comment Add(Comment child)
    {
        _children.Add(child);
        return child;
    }
}
