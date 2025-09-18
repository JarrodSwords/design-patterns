using FluentAssertions;

namespace CharacterProgression.Domain6.State;

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
    #region Implementation

    public override Xp MaxXp => Character.MaxXp;
    public override Character CreateLevelable(Xp xp) => new(xp);
    public override ILeveler CreateLeveler(Character character) => new CharacterLeveler().For(character);

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

        character.Xp.Should().Be((ushort) 12);
        character2.Xp.Should().Be((ushort) 34);
    }

    [Theory]
    [InlineData(1, 49)]
    [InlineData(100, 148)]
    public void GivenChangingEquipment_ThenXpGainIsDependentOnEquipment(ushort initial, ushort expected)
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

    #endregion
}
