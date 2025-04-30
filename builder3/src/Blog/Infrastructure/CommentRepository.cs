using DesignPatterns.Builder3.Blog.Domain;
using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace DesignPatterns.Builder3.Blog.Infrastructure;

public class CommentRepository : ICommentRepository
{
    private readonly List<Comment> _comments = [];
    private ICommentBuilder? _builder;

    public ICommentRepository Seed(IEnumerable<Comment> seed)
    {
        _comments.Clear();
        _comments.AddRange(seed);
        return this;
    }

    public ICommentRepository Configure(ICommentBuilder builder)
    {
        _builder = builder;
        return this;
    }

    public Result Find(CommentId id)
    {
        foreach (var c in _comments.Where(x => x.RootId == id))
            _builder!.Add(c);

        return Success();
    }

    public Result Find(PostId id) => throw new NotImplementedException();
}
