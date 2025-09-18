namespace CharacterProgression.Domain2.Composition;

public interface ILevelable
{
    Xp Xp { get; }
    void Add(Xp xp);
    void Set(Xp xp);
}

public abstract class Levelable(Xp maxXp, Xp xp) : ILevelable
{
    public Xp MaxXp { get; protected set; } = maxXp;
    public Xp Xp { get; protected set; } = xp;

    public abstract void Add(Xp xp);
    public abstract void Set(Xp xp);
}

public class StandardRate(Xp maxXp, Xp xp) : Levelable(maxXp, xp)
{
    public override void Add(Xp xp)
    {
        Xp = (Xp) Math.Min(Xp + xp, MaxXp);
    }

    public override void Set(Xp xp)
    {
        Xp = xp;
    }
}

public class BoostedRate(Xp maxXp, Xp xp) : Levelable(maxXp, xp)
{
    public override void Add(Xp xp)
    {
        Xp = (Xp) Math.Min(Xp + xp * 2, MaxXp);
    }

    public override void Set(Xp xp)
    {
        Xp = xp;
    }
}

public class Character(Xp? xp = null) : ILevelable
{
    public static readonly Xp MaxXp = 9999;
    private Accessory _accessory;
    private Levelable _levelable = new StandardRate(MaxXp, xp ?? 0);

    public Accessory Accessory
    {
        get => _accessory;
        private set
        {
            _accessory = value;

            if (_accessory.GetType() == typeof(ExpBooster))
                _levelable = CreateBoostedRate();
        }
    }

    public Character Equip(Accessory accessory)
    {
        Accessory = accessory;
        return this;
    }

    private Levelable CreateBoostedRate() => new BoostedRate(MaxXp, Xp);

    public Xp Xp => _levelable.Xp;

    public void Add(Xp xp) => _levelable.Add(xp);
    public void Set(Xp xp) => _levelable.Set(xp);
}

public class Attribute(Xp? xp = null) : ILevelable
{
    public static readonly Xp MaxXp = 255;
    private readonly Levelable _levelable = new StandardRate(MaxXp, xp ?? 0);

    public Xp Xp => _levelable.Xp;

    public void Add(Xp xp) => _levelable.Add(xp);
    public void Set(Xp xp) => _levelable.Set(xp);
}
