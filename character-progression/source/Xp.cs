using Jgs.ValueObjects;

namespace CharacterProgression;

public class Xp(ushort value) : TinyType<ushort>(value)
{
    public static implicit operator Xp(ushort source) => new(source);
}
