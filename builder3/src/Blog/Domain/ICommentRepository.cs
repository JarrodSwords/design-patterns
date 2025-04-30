using Jgs.Errors.Results;

namespace DesignPatterns.Builder3.Blog.Domain;

public interface ICommentRepository
{
    ICommentRepository Configure(ICommentBuilder builder);
    Result Find(CommentId id);
    Result Find(PostId id);
}
