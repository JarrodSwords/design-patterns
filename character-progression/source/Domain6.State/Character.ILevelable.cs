using System.Linq.Expressions;

namespace CharacterProgression.Domain6.State;

public partial class Character : ILevelable
{
    public static readonly Xp MaxXp = 9999;
    private Xp _xp = xp ?? 0;

    public Xp Xp
    {
        get => _xp;
        private set => _xp = Math.Min(value, MaxXp);
    }

    public class BoostedLeveler(Character character) : ILeveler
    {
        public void Add(Xp xp)
        {
            character.Xp += (Xp) (xp * 2);
        }
    }

    public class StandardLeveler(Character character) : ILeveler
    {
        public void Add(Xp xp)
        {
            character.Xp += xp;
        }
    }
}

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
            ? new Character.BoostedLeveler(Character)
            : new Character.StandardLeveler(Character);
    }

    public void Add(Xp xp)
    {
        _state.Add(xp);
    }
}

public class IsBoosted : Specification<Character>
{
    protected override Expression<Func<Character, bool>> ToExpression() =>
        character => character.Accessory.GetType() == typeof(ExpBooster);
}
