using System.Linq.Expressions;

namespace CharacterProgression.Domain7.Encapsulation;

public partial class Character(Xp? xp = null) : ILevelable
{
    public static readonly Xp MaxXp = 9999;
    private readonly Levelable _levelable = new(xp ?? 0, MaxXp);

    public Level Level => _levelable.Level;
    public Xp Xp => _levelable.Xp;
    public void Add(Xp xp) => _levelable.Add(xp);
}

public class IsBoosted : Specification<Character>
{
    protected override Expression<Func<Character, bool>> ToExpression() =>
        character => character.Accessory.GetType() == typeof(ExpBooster);
}
