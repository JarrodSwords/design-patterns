namespace CharacterProgression.Domain7.Encapsulation;

public interface ILevelable
{
    Level Level { get; }
    Xp Xp { get; }
    void Add(Xp xp);
}

public class Levelable(Xp xp, Xp maxXp) : ILevelable
{
    private Xp _xp = xp;

    public Level Level { get; set; }

    public Xp Xp
    {
        get => _xp;
        set => _xp = Math.Min(value, maxXp);
    }

    public void Add(Xp xp)
    {
        Xp += xp;
    }
}
