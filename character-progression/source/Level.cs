using Jgs.ValueObjects;

namespace CharacterProgression;

public class Level(byte value) : TinyType<byte>(value)
{
    public static implicit operator Level(byte source) => new(source);
}
