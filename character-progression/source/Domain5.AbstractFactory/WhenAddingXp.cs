using FluentAssertions;

namespace CharacterProgression.Domain5.AbstractFactory;

public abstract class WhenAddingXp<T> where T : ILevelable
{
    #region Implementation

    public abstract Xp MaxXp { get; }
    public abstract T CreateLevelable(Xp xp);
    public abstract ILeveler CreateLeveler(T leveler);

    #endregion

    #region Requirements

    [Fact]
    public void GivenMaxXp_ThenXpIsNotAdded()
    {
        var levelable = CreateLevelable(MaxXp);
        var leveler = CreateLeveler(levelable);

        leveler.Add(10);

        levelable.Xp.Should().Be(MaxXp);
    }

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void ThenXpIsAdded(ushort initial, ushort gained)
    {
        var levelable = CreateLevelable(initial);
        var leveler = CreateLeveler(levelable);

        leveler.Add(gained);

        levelable.Xp.Should().Be((ushort) (initial + gained));
    }

    [Fact]
    public void ThenXpIsClamped()
    {
        var levelable = CreateLevelable((Xp) (MaxXp - 10));
        var leveler = CreateLeveler(levelable);

        leveler.Add(20);

        levelable.Xp.Should().Be(MaxXp);
    }

    #endregion
}

public class WhenAddingXpToAttribute : WhenAddingXp<Attribute>
{
    public override Xp MaxXp => Attribute.MaxXp;
    public override Attribute CreateLevelable(Xp xp) => new(xp);
    public override ILeveler CreateLeveler(Attribute attribute) => new Attribute.StandardLeveler(attribute);
}

public class WhenAddingXpToCharacter : WhenAddingXp<Character>
{
    #region Setup

    private readonly CharacterLevelerFactory _factory = new();

    #endregion

    #region Implementation

    public override Xp MaxXp => Character.MaxXp;
    public override Character CreateLevelable(Xp xp) => new(xp);
    public override ILeveler CreateLeveler(Character character) => _factory.Create(character);

    #endregion

    #region Requirements

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void GivenBoostedRate_ThenXpGainedIsDoubled(ushort initial, ushort gained)
    {
        var character = CreateLevelable(initial);
        character.Equip(new ExpBooster());

        var leveler = CreateLeveler(character);
        leveler.Add(gained);

        character.Xp.Should().Be((ushort) (initial + gained * 2));
    }

    #endregion
}
