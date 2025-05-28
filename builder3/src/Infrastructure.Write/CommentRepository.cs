using DesignPatterns.Builder3.Domain;
using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace DesignPatterns.Builder3.Infrastructure.Write;

public class CommentRepository : ICommentRepository
{
    private readonly List<Message> _comments = [];

    public ICommentRepository Seed(IEnumerable<Message> seed)
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
