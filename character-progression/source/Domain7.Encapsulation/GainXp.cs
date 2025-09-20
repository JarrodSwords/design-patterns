namespace CharacterProgression.Domain7.Encapsulation;

/// <remarks>Simulated command</remarks>
public record GainXp(ushort Xp);

/// <remarks>Simulated command handler</remarks>
public class GainXpHandler
{
    public void Handle(GainXp command)
    {
        var character = new Character();

        var leveler = new CharacterLeveler().For(character);

        leveler.Add(command.Xp);
    }
}
