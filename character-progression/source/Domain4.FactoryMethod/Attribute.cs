namespace CharacterProgression.Domain4.FactoryMethod;

public class Attribute(Xp? xp = null) : ILevelable
{
    public static readonly Xp MaxXp = 255;
    public Xp Xp { get; private set; } = xp ?? 0;
    public IProgressionRate CreateProgressionRate() => new StandardRate(this);

    public class StandardRate(Attribute attribute) : IProgressionRate
    {
        public void Add(Xp xp)
        {
            attribute.Xp = (Xp) Math.Min(attribute.Xp + xp, MaxXp);
        }
    }
}
