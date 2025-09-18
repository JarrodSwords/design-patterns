using System.Linq.Expressions;

namespace CharacterProgression.Domain5.AbstractFactory;

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

public class IsBoosted : Specification<Character>
{
    protected override Expression<Func<Character, bool>> ToExpression() =>
        character => character.Accessory.GetType() == typeof(ExpBooster);
}

public class CharacterLevelerFactory : ILevelerFactory<Character>
{
    public ILeveler Create(Character character) =>
        new IsBoosted().IsSatisfiedBy(character)
            ? new Character.BoostedLeveler(character)
            : new Character.StandardLeveler(character);
}
