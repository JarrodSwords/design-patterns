using static DesignPatterns.Builder3.Domain.ICommentBuilder;

namespace DesignPatterns.Builder3.Domain;

public partial class Comment
{
    private Comment(CommentArgs source) : this(
        source.Id,
        source.PostId,
        source.UserId,
        source.Text,
        source.Timestamp
    )
    {
    }

    public static implicit operator Comment(CommentArgs source) => new(source);

    public class Builder : ICommentBuilder
    {
        private readonly Dictionary<CommentId, Comment> _comments = new();

        public Comment GetComment() => _comments.Values.First(x => x.Parent == null);

        public ICommentBuilder Add(CommentArgs args)
        {
            Comment comment = args;

            _comments.TryAdd(comment.Id, comment);

            if (args.ParentId is null)
                return this;

            var parent = _comments[args.ParentId];
            parent.Add(comment);

            return this;
        }
    }
}
