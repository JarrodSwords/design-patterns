namespace CharacterProgression.Domain3.Service;

public enum ProgressionType
{
    Standard,
    Boosted
}

public interface IProgressable
{
    public ProgressionType ProgressionType { get; }
    Xp Xp { get; }
    void Set(Xp xp);
}

public abstract class ProgressionRate
{
    public abstract void Add(IProgressable progressable, Xp xp, Xp maxXp);
}

public class StandardRate : ProgressionRate
{
    public override void Add(IProgressable progressable, Xp xp, Xp maxXp)
    {
        progressable.Set((Xp) Math.Min(progressable.Xp + xp, maxXp));
    }
}

public class BoostedRate : ProgressionRate
{
    public override void Add(IProgressable progressable, Xp xp, Xp maxXp)
    {
        progressable.Set((Xp) Math.Min(progressable.Xp + xp * 2, maxXp));
    }
}

public abstract class Accessory
{
}

public class ExpBooster : Accessory
{
}

public class Character(ProgressionType progressionType = ProgressionType.Standard, Xp? xp = null) : IProgressable
{
    public static readonly Xp MaxXp = 9999;
    private Accessory _accessory;

    public Accessory Accessory
    {
        get => _accessory;
        private set
        {
            _accessory = value;

            if (_accessory.GetType() == typeof(ExpBooster))
                ProgressionType = ProgressionType.Boosted;
        }
    }

    public Character Equip(Accessory accessory)
    {
        Accessory = accessory;
        return this;
    }

    public ProgressionType ProgressionType { get; private set; } = progressionType;
    public Xp Xp { get; private set; } = xp ?? 0;

    public void Set(Xp xp) => Xp = xp;
}

public class Attribute(ProgressionType progressionType = ProgressionType.Standard, Xp? xp = null) : IProgressable
{
    public static readonly Xp MaxXp = 255;
    public ProgressionType ProgressionType { get; } = progressionType;
    public Xp Xp { get; private set; } = xp ?? 0;
    public void Set(Xp xp) => Xp = xp;
}

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
