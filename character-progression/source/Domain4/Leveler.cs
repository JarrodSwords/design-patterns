namespace CharacterProgression.Domain4;

public interface IProgressionRate
{
    void Add(Xp xp);
}

public interface ILevelable
{
    Xp Xp { get; }
    IProgressionRate CreateProgressionRate();
}

public interface ILeveler
{
    void Level(ILevelable levelable, Xp xp);
}

public class Leveler : ILeveler
{
    public void Level(ILevelable levelable, Xp xp)
    {
        var rate = levelable.CreateProgressionRate();
        rate.Add(xp);
    }
}
