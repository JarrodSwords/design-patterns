namespace CharacterProgression.Domain6.State;

public interface ILeveler
{
    void Add(Xp xp);
}

public interface ILevelable
{
    Xp Xp { get; }
}

public interface ILevelerFactory<in T> where T : ILevelable
{
    ILeveler Create(T levelable);
}

/// <remarks>Simulated command</remarks>
public record GainXp(ushort Xp);

/// <remarks>Simulated command handler</remarks>
public class GainXpHandler
{
    public void Handle(GainXp command)
    {
        var character = new Character();

        var leveler = new CharacterLevelerFactory().Create(character);

        leveler.Add(command.Xp);
    }
}
