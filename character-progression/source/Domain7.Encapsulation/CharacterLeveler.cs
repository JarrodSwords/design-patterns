namespace CharacterProgression.Domain7.Encapsulation;

public class CharacterLeveler : ILeveler
{
    private Character _character;
    private ILeveler _state;

    public Character Character
    {
        get => _character;
        set
        {
            _character = value;
            _character.AccessoryEquipped += AccessoryEquipped;
            UpdateState();
        }
    }

    public CharacterLeveler For(Character character)
    {
        Character = character;
        return this;
    }

    private void AccessoryEquipped(object? sender, EventArgs args)
    {
        UpdateState();
    }

    private void UpdateState()
    {
        _state = new IsBoosted().IsSatisfiedBy(Character)
            ? new BoostedLeveler(Character)
            : new StandardLeveler(Character);
    }

    public void Add(Xp xp) => _state.Add(xp);
}
