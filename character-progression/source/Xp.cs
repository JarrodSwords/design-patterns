using Jgs.ValueObjects;

namespace CharacterProgression;

public class Xp(uint value) : TinyType<uint>(value)
{
    public static implicit operator Xp(uint source) => new(source);
}
