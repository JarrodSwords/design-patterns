namespace DesignPatterns.Builder3.Blog.Infrastructure.Read;

public partial class Comment
{
    private Comment(Database.Comment source)
    {
        Id = source.Id;
        UserId = source.UserId;
        Text = source.Text;
        Timestamp = source.Timestamp;
    }

    public static implicit operator Comment(Database.Comment source) => new(source);

    public class Builder : ICommentBuilder
    {
        private readonly Dictionary<uint, Comment> _comments = new();

        public Comment GetComment() => _comments.Values.First();

        public ICommentBuilder Add(Database.Comment record)
        {
            Comment comment = record;

            _comments.TryAdd(comment.Id, comment);

            if (record.ParentId is null)
                return this;

            var parent = _comments[record.ParentId.Value];
            parent.Add(comment);

            return this;
        }
    }
}
