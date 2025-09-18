namespace CharacterProgression.Domain3.AskingNotTelling;

public class XpService
{
    private readonly Dictionary<ProgressionType, Func<ProgressionRate>> _createProgressionRate = new()
    {
        { ProgressionType.Standard, () => new StandardRate() },
        { ProgressionType.Boosted, () => new BoostedRate() }
    };

    public void Add(ILevelable levelable, Xp xp, Xp maxXp)
    {
        _createProgressionRate[levelable.ProgressionType]().Add(levelable, xp, maxXp);
    }
}
