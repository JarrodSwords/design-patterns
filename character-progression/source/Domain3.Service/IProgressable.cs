namespace CharacterProgression.Domain3.Service;

public interface IProgressable
{
    Xp Xp { get; }
    void Add(Xp xp);
    void Set(Xp xp);
}

public class Progressable(Xp xp) : IProgressable
{
    public Xp Xp { get; private set; } = xp;

    public void Add(Xp xp)
    {
        Xp += xp;
    }

    public void Set(Xp xp)
    {
        Xp = xp;
    }
}

public class Character(Xp? xp = null) : IProgressable
{
    private readonly Progressable _progressable = new(xp ?? 0);

    public Xp Xp => _progressable.Xp;

    public void Add(Xp xp) => _progressable.Add(xp);
    public void Set(Xp xp) => _progressable.Set(xp);
}

public class Attribute(Xp? xp = null) : IProgressable
{
    private readonly Progressable _progressable = new(xp ?? 0);

    public Xp Xp => _progressable.Xp;

    public void Add(Xp xp) => _progressable.Add(xp);
    public void Set(Xp xp) => _progressable.Set(xp);
}

public class ProgressService
{
}
