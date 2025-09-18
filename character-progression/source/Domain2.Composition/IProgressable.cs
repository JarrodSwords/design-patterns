namespace CharacterProgression.Domain2.Composition;

public interface IProgressable
{
    Xp Xp { get; }
    void Add(Xp xp);
    void Set(Xp xp);
}

public class Progressable(Xp maxXp, Xp xp) : IProgressable
{
    public Xp Xp { get; private set; } = xp;

    public void Add(Xp xp)
    {
        Xp = (Xp) Math.Min(Xp + xp, maxXp);
    }

    public void Set(Xp xp)
    {
        Xp = xp;
    }
}

public class Character(Xp? xp = null) : IProgressable
{
    public static readonly Xp MaxXp = 9999;
    private readonly Progressable _progressable = new(MaxXp, xp ?? 0);

    public Xp Xp => _progressable.Xp;

    public void Add(Xp xp) => _progressable.Add(xp);
    public void Set(Xp xp) => _progressable.Set(xp);
}

public class Attribute(Xp? xp = null) : IProgressable
{
    public static readonly Xp MaxXp = 255;
    private readonly Progressable _progressable = new(MaxXp, xp ?? 0);

    public Xp Xp => _progressable.Xp;

    public void Add(Xp xp) => _progressable.Add(xp);
    public void Set(Xp xp) => _progressable.Set(xp);
}
