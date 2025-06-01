using Jgs.Errors.Results;

namespace DesignPatterns.Builder3.Infrastructure.Read;

public partial class Comment
{
    private readonly List<Comment> _children = [];

    private Comment(uint id, string text, DateTime timestamp, User user)
    {
        Id = id;
        Text = text;
        Timestamp = timestamp;
        User = user;
    }

    private Comment Add(Comment child)
    {
        _children.Add(child);
        return child;
    }

    private static Result<Comment> From(Database.Message message, Database.User user) =>
        new Comment(
            message.Id,
            message.Text,
            message.Timestamp,
            user
        );

    public class Builder(Thread thread) : IMessageBuilder
    {
        private readonly Dictionary<uint, Comment> _comments = new();

        public object Add(Database.Message message, Database.User user)
        {
            return From(message, user)
                .Then(
                    x =>
                    {
                        if (!_comments.TryAdd(x.Id, x))
                            return x;

                        if (message.ParentId is not null)
                            _comments[message.ParentId.Value].Add(x);
                        else
                            thread.Add(x);

                        return x;
                    }
                );
        }
    }
}
