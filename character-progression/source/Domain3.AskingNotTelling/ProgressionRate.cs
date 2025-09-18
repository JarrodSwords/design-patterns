namespace CharacterProgression.Domain3.AskingNotTelling;

public enum ProgressionType
{
    Standard,
    Boosted
}

public abstract class ProgressionRate
{
    public abstract void Add(IProgressable progressable, Xp xp, Xp maxXp);
}

public class StandardRate : ProgressionRate
{
    public override void Add(IProgressable progressable, Xp xp, Xp maxXp)
    {
        progressable.Set((Xp) Math.Min(progressable.Xp + xp, maxXp));
    }
}

public class BoostedRate : ProgressionRate
{
    public override void Add(IProgressable progressable, Xp xp, Xp maxXp)
    {
        progressable.Set((Xp) Math.Min(progressable.Xp + xp * 2, maxXp));
    }
}
