namespace CharacterProgression.Domain7.Encapsulation;

public partial class Character(Xp? xp = null)
{
    private Accessory _accessory = new None();
    public event EventHandler? AccessoryEquipped;

    public Accessory Accessory
    {
        get => _accessory;
        private set
        {
            _accessory = value;
            AccessoryEquipped?.Invoke(this, null);
        }
    }

    public Character Equip(Accessory accessory)
    {
        Accessory = accessory;
        return this;
    }
}
