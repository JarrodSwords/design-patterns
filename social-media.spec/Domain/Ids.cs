using Jgs.ValueObjects;

namespace Examples.SocialMedia.Domain;

public class Id(uint value) : TinyType<uint>(value);

public class ContextId(uint value) : Id(value)
{
    public static implicit operator ContextId(uint source) => new(source);
}

public class MessageId(uint value) : Id(value)
{
    public static implicit operator MessageId(uint source) => new(source);
}

public class UserId(uint value) : Id(value)
{
    public static implicit operator UserId(uint source) => new(source);
}
