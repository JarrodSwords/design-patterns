namespace CharacterProgression.Domain7.Encapsulation;

public interface ILeveler
{
    void Add(Xp xp);
}

public class StandardLeveler(ILevelable levelable) : ILeveler
{
    public void Add(Xp xp) => levelable.Add(xp);
}

public class BoostedLeveler(ILevelable levelable) : ILeveler
{
    public void Add(Xp xp) => levelable.Add(xp * 2);
}
