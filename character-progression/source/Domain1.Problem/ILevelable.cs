namespace CharacterProgression.Domain1.Problem;

/// <summary>
///     Represents an object that can be leveled with <see cref="CharacterProgression.Xp" />
/// </summary>
public interface ILevelable
{
    Xp Xp { get; }
    void Add(Xp xp);
    void Set(Xp xp);
}

public class Character(Xp? xp = null) : ILevelable
{
    public static readonly Xp MaxXp = 9999;
    private Xp _xp = xp ?? 0;

    public Xp Xp
    {
        get => _xp;
        private set => _xp = Math.Min(value, MaxXp);
    }

    public void Add(Xp xp) => Xp += xp;
    public void Set(Xp xp) => Xp = xp;
}

public class Attribute(Xp? xp = null) : ILevelable
{
    public static readonly Xp MaxXp = 255;
    private Xp _xp = xp ?? 0;

    public Xp Xp
    {
        get => _xp;
        private set => _xp = Math.Min(value, MaxXp);
    }

    public void Add(Xp xp) => Xp += xp;
    public void Set(Xp xp) => Xp = xp;
}
