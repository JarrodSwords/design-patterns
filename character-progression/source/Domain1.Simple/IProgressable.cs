namespace CharacterProgression.Domain1.Simple;

public interface IProgressable
{
    Xp Xp { get; }
    void Add(Xp xp);
    void Set(Xp xp);
}

public class Character(Xp? xp = null) : IProgressable
{
    public Xp Xp { get; private set; } = xp ?? 0;

    public void Add(Xp xp)
    {
        Xp += xp;
    }

    public void Set(Xp xp)
    {
        Xp = xp;
    }
}

public class Attribute(Xp? xp = null) : IProgressable
{
    public Xp Xp { get; private set; } = xp ?? 0;

    public void Add(Xp xp)
    {
        Xp += xp;
    }

    public void Set(Xp xp)
    {
        Xp = xp;
    }
}
