namespace DesignPatterns.Builder3.Blog.Domain;

public partial class Chat
{
    private readonly SortedList<DateTime, Message> _messages = [];

    private Chat(uint id)
    {
        Id = id;
    }

    public PostId Id { get; }

    public IReadOnlyList<Message> Messages => _messages.Values.AsReadOnly();

    private Chat Add(Message message)
    {
        _messages.Add(message.Timestamp, message);
        return this;
    }
}
