using DesignPatterns.Builder3.Blog.Domain;
using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace DesignPatterns.Builder3.Blog.Infrastructure.Write;

public class CommentRepository : ICommentRepository
{
    private readonly List<Comment> _comments = [];

    public ICommentRepository Seed(IEnumerable<Comment> seed)
    {
        _comments.Clear();
        _comments.AddRange(seed);
        return this;
    }

    public Result Find(CommentId id, ICommentBuilder builder)
    {
        foreach (var c in _comments.Where(x => x.RootId == id))
            builder.Add(c);

        return Success();
    }

    public Result Find(PostId id) => throw new NotImplementedException();
}
