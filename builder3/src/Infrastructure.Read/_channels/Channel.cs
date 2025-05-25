using System.Collections;

namespace DesignPatterns.Builder3.Infrastructure.Read._channels;

public partial class Channel : IEnumerable<Message>
{
    private readonly SortedDictionary<DateTime, Message> _messages = new();

    private void Add(Message message)
    {
        _messages.Add(message.Timestamp, message);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<Message> GetEnumerator() => _messages.Values.GetEnumerator();
}
