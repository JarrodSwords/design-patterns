namespace CharacterProgression.Domain3.AskingNotTelling;

public class XpService
{
    private readonly Dictionary<ProgressionType, Func<ProgressionRate>> _createProgressionRate = new()
    {
        { ProgressionType.Standard, () => new StandardRate() },
        { ProgressionType.Boosted, () => new BoostedRate() }
    };

    public void Add(IProgressable progressable, Xp xp, Xp maxXp)
    {
        _createProgressionRate[progressable.ProgressionType]().Add(progressable, xp, maxXp);
    }
}
