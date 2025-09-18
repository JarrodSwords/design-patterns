namespace CharacterProgression.Domain4.AbstractFactory;

public partial class Character : ILevelable
{
    public static readonly Xp MaxXp = 9999;
    private ProgressionType _progressionType = progressionType;
    private Xp _xp = xp ?? 0;

    public Xp Xp
    {
        get => _xp;
        private set => _xp = Math.Min(value, MaxXp);
    }

    public IProgressionRate CreateProgressionRate() =>
        _progressionType switch
        {
            ProgressionType.Boosted => new BoostedRate(this),
            ProgressionType.Standard => new StandardRate(this),
            _ => new StandardRate(this)
        };

    public class BoostedRate(Character character) : IProgressionRate
    {
        public void Add(Xp xp)
        {
            character.Xp += (Xp) (xp * 2);
        }
    }

    public class StandardRate(Character character) : IProgressionRate
    {
        public void Add(Xp xp)
        {
            character.Xp += xp;
        }
    }
}
