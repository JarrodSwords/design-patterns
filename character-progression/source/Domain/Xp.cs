using Jgs.ValueObjects;

namespace CharacterProgression.Domain;

public class Xp(ushort value) : TinyType<ushort>(value)
{
    public static implicit operator Xp(ushort source) => new(source);
}
