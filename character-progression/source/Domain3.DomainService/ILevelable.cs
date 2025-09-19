namespace CharacterProgression.Domain3.DomainService;

public interface ILevelable
{
    public ProgressionType ProgressionType { get; }
    Xp Xp { get; }
    void Set(Xp xp);
}

public class Character(ProgressionType progressionType = ProgressionType.Standard, Xp? xp = null) : ILevelable
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

public class Attribute(ProgressionType progressionType = ProgressionType.Standard, Xp? xp = null) : ILevelable
{
    public static readonly Xp MaxXp = 255;
    public ProgressionType ProgressionType { get; } = progressionType;
    public Xp Xp { get; private set; } = xp ?? 0;
    public void Set(Xp xp) => Xp = xp;
}
