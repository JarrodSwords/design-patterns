using static DesignPatterns.Builder3.Blog.Domain.ICommentBuilder;

namespace DesignPatterns.Builder3.Blog.Infrastructure.Write;

public record Comment(
    uint Id,
    uint? ParentId,
    uint PostId,
    uint RootId,
    uint UserId,
    string Text,
    DateTime Timestamp
)
{
    public static implicit operator CommentArgs(Comment source) =>
        new(
            source.Id,
            source.ParentId,
            source.PostId,
            source.UserId,
            source.Text,
            source.Timestamp
        );
}
