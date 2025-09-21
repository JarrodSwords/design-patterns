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

    private void CalculateLevel() => Level = Calculator.GetLevel(Xp);

    public Level Level { get; private set; }

    public Xp Xp
    {
        get => _xp;
        set
        {
            _xp = Math.Min(value, maxXp);
            CalculateLevel();
        }
    }

    public void Add(Xp xp)
    {
        Xp += xp;
    }
}
