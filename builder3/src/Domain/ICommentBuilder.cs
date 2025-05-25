namespace DesignPatterns.Builder3.Domain;

public interface ICommentBuilder
{
    ICommentBuilder Add(CommentArgs args);

    public record CommentArgs(
        uint Id,
        uint? ParentId,
        uint PostId,
        uint UserId,
        string Text,
        DateTime Timestamp
    );
}
