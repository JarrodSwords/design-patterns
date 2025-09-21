using FluentAssertions;

namespace CharacterProgression.Domain7.Encapsulation;

public abstract class WhenAddingXp<T> where T : ILevelable
{
    #region Implementation

    public abstract Xp MaxXp { get; }
    public abstract T CreateLevelable(Xp xp);
    public abstract ILeveler CreateLeveler(T leveler);

    public virtual void ThenLevelIsExpected(uint initial, uint gained, byte level)
    {
        var levelable = CreateLevelable(initial);
        var leveler = CreateLeveler(levelable);

        leveler.Add(gained);

        levelable.Level.Should().Be(level);
    }

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
    public void ThenXpIsAdded(uint initial, uint gained)
    {
        var levelable = CreateLevelable(initial);
        var leveler = CreateLeveler(levelable);

        leveler.Add(gained);

        levelable.Xp.Should().Be(initial + gained);
    }

    [Fact]
    public void ThenXpIsClamped()
    {
        var levelable = CreateLevelable(MaxXp - 10);
        var leveler = CreateLeveler(levelable);

        leveler.Add(20);

        levelable.Xp.Should().Be(MaxXp);
    }

    #endregion
}

public class WhenAddingXpToAttribute : WhenAddingXp<Attribute>
{
    #region Implementation

    public override Xp MaxXp => Attribute.MaxXp;
    public override Attribute CreateLevelable(Xp xp) => new(xp);
    public override ILeveler CreateLeveler(Attribute attribute) => new StandardLeveler(attribute);

    #endregion

    #region Requirements

    [Theory]
    [InlineData(0, 5, 1)]
    [InlineData(0, 83, 2)]
    [InlineData(80, 5, 2)]
    public override void ThenLevelIsExpected(uint initial, uint gained, byte level) =>
        base.ThenLevelIsExpected(initial, gained, level);

    #endregion
}

public class WhenAddingXpToCharacter : WhenAddingXp<Character>
{
    #region Implementation

    public override Xp MaxXp => Character.MaxXp;
    public override Character CreateLevelable(Xp xp) => new(xp);
    public override ILeveler CreateLeveler(Character character) => new CharacterLeveler().For(character);

    #endregion

    #region Requirements

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void GivenBoostedRate_ThenXpGainedIsDoubled(uint initial, uint gained)
    {
        var character = CreateLevelable(initial);
        character.Equip(new ExpBooster());

        var leveler = CreateLeveler(character);
        leveler.Add(gained);

        character.Xp.Should().Be(initial + gained * 2);
    }

    [Fact]
    public void GivenChangingCharacters_ThenXpIsAppliedToCorrectCharacters()
    {
        var character = CreateLevelable(1);
        var character2 = CreateLevelable(1);

        var leveler = new CharacterLeveler().For(character);

        leveler.Add(5); //6, 1

        leveler.For(character2);

        leveler.Add(10); //6, 11

        character.Equip(new ExpBooster());

        leveler.Add(7); //6, 18

        character2.Equip(new ExpBooster());

        leveler.Add(8); //6, 34

        leveler.For(character);

        leveler.Add(3); //12, 34

        character.Xp.Should().Be(12u);
        character2.Xp.Should().Be(34u);
    }

    [Theory]
    [InlineData(1, 49)]
    [InlineData(100, 148)]
    public void GivenChangingEquipment_ThenXpGainIsDependentOnEquipment(uint initial, uint expected)
    {
        var character = CreateLevelable(initial);
        var leveler = CreateLeveler(character);

        leveler.Add(5); //5
        leveler.Add(10); //15

        character.Equip(new ExpBooster());

        leveler.Add(7); //29
        leveler.Add(8); //45

        character.Equip(new None());

        leveler.Add(3); //48

        character.Xp.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 5, 1)]
    [InlineData(0, 83, 2)]
    [InlineData(80, 5, 2)]
    [InlineData(0, 500, 5)]
    public override void ThenLevelIsExpected(uint initial, uint gained, byte level) =>
        base.ThenLevelIsExpected(initial, gained, level);

    #endregion
}
