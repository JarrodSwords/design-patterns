namespace CharacterProgression.Domain4.FactoryMethod;

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
    void Add(ILevelable levelable, Xp xp);
}

public class Leveler : ILeveler
{
    public void Add(ILevelable levelable, Xp xp)
    {
        var rate = levelable.CreateProgressionRate();
        rate.Add(xp);
    }
}
