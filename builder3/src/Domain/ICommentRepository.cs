using Jgs.Errors.Results;

namespace DesignPatterns.Builder3.Domain;

public interface ICommentRepository
{
    Result Find(CommentId id, ICommentBuilder builder);
    Result Find(PostId id);
}
