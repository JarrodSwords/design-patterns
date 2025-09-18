namespace CharacterProgression.Domain5.AbstractFactory;

public partial class Character(Xp? xp = null)
{
    public Accessory Accessory { get; private set; } = new None();

    public Character Equip(Accessory accessory)
    {
        Accessory = accessory;
        return this;
    }
}
