namespace CharacterProgression.Domain6.State;

public class Attribute(Xp? xp = null) : ILevelable
{
    public static readonly Xp MaxXp = 255;
    public Xp Xp { get; private set; } = xp ?? 0;

    public class StandardLeveler(Attribute attribute) : ILeveler
    {
        public void Add(Xp xp)
        {
            attribute.Xp = (Xp) Math.Min(attribute.Xp + xp, MaxXp);
        }
    }
}
