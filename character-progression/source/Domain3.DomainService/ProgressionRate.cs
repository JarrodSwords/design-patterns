namespace CharacterProgression.Domain3.DomainService;

public enum ProgressionType
{
    Standard,
    Boosted
}

public abstract class ProgressionRate
{
    public abstract void Add(ILevelable levelable, Xp xp, Xp maxXp);
}

public class StandardRate : ProgressionRate
{
    public override void Add(ILevelable levelable, Xp xp, Xp maxXp)
    {
        levelable.Set((Xp) Math.Min(levelable.Xp + xp, maxXp));
    }
}

public class BoostedRate : ProgressionRate
{
    public override void Add(ILevelable levelable, Xp xp, Xp maxXp)
    {
        levelable.Set((Xp) Math.Min(levelable.Xp + xp * 2, maxXp));
    }
}
