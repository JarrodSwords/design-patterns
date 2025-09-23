namespace CharacterProgression.Domain4.FactoryMethod;

public partial class Character(
    ProgressionType progressionType = ProgressionType.Standard,
    Xp? xp = null
)
{
    private Accessory _accessory;

    public Accessory Accessory
    {
        get => _accessory;
        private set
        {
            _accessory = value;

            if (_accessory.GetType() == typeof(ExpBooster))
                _progressionType = ProgressionType.Boosted;
        }
    }

    public Character Equip(Accessory accessory)
    {
        Accessory = accessory;
        return this;
    }
}
