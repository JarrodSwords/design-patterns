﻿using System.Collections;

namespace Examples.SocialMedia.Infrastructure.Read;

public partial class Channel : IEnumerable<Message>
{
    private readonly SortedList<DateTime, Message> _messages = new();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator<Message> GetEnumerator() => _messages.Values.GetEnumerator();
}
