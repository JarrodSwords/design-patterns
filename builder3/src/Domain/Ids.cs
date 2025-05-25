using Jgs.ValueObjects;

namespace DesignPatterns.Builder3.Domain;

public class Id(uint value) : TinyType<uint>(value);

public class CommentId(uint value) : Id(value)
{
    public static implicit operator CommentId(uint source) => new(source);
}

public class MessageId(uint value) : Id(value)
{
    public static implicit operator MessageId(uint source) => new(source);
}

public class PostId(uint value) : Id(value)
{
    public static implicit operator PostId(uint source) => new(source);
}

public class UserId(uint value) : Id(value)
{
    public static implicit operator UserId(uint source) => new(source);
}
