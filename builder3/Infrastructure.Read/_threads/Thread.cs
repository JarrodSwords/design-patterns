﻿using System.Collections;

namespace Examples.SocialMedia.Infrastructure.Read;

public class Thread : IEnumerable<Comment>
{
    private readonly List<Comment> _comments = new();

    internal void Add(Comment comment)
    {
        _comments.Add(comment);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator<Comment> GetEnumerator() => _comments.GetEnumerator();
}
