namespace DesignPatterns.Builder3.Domain;

public partial class Comment
{
    private readonly List<Comment> _children = [];

    private Comment(
        uint id,
        uint postId,
        uint userId,
        string text,
        DateTime timestamp
    )
    {
        Id = id;
        PostId = postId;
        UserId = userId;
        Text = text;
        Timestamp = timestamp;
    }

    public CommentId Id { get; }
    public PostId PostId { get; }
    public UserId UserId { get; }
    public IReadOnlyList<Comment> Children => _children;

    public ushort Descendants
    {
        get
        {
            ushort value = 0;
            PreorderTraversal(this, () => value++);
            return --value;
        }
    }

    public byte Height
    {
        get
        {
            if (Children.Any())
                return (byte) (Children.Max(x => x.Height) + 1);

            return 1;
        }
    }

    public Comment? Parent { get; private set; }
    public string Text { get; }
    public DateTime Timestamp { get; }

    private Comment Add(Comment child)
    {
        _children.Add(child);
        child.Parent = this;
        return child;
    }

    private static void PreorderTraversal(Comment comment, Action action)
    {
        action();

        foreach (var c in comment._children)
            PreorderTraversal(c, action);
    }
}
