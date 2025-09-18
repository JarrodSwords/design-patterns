using FluentAssertions;

namespace CharacterProgression.Domain4.FactoryMethod;

public abstract class WhenAddingXp
{
    #region Setup

    protected readonly Leveler Leveler = new();
    protected ILevelable Levelable;

    #endregion

    #region Implementation

    protected abstract Xp MaxXp { get; }
    public abstract ILevelable CreateLevelable(Xp xp);

    #endregion

    #region Requirements

    [Fact]
    public void GivenMaxXp_ThenXpIsNotAdded()
    {
        CreateLevelable(MaxXp);

        Leveler.Level(Levelable, 10);

        Levelable.Xp.Should().Be(MaxXp);
    }

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void ThenXpIsAdded(ushort initial, ushort gained)
    {
        CreateLevelable(initial);

        Leveler.Level(Levelable, gained);

        Levelable.Xp.Should().Be((ushort) (initial + gained));
    }

    [Fact]
    public void ThenXpIsClamped()
    {
        CreateLevelable((Xp) (MaxXp - 10));

        Leveler.Level(Levelable, 20);

        Levelable.Xp.Should().Be(MaxXp);
    }

    #endregion
}

public class WhenAddingXpToAttribute : WhenAddingXp
{
    protected override Xp MaxXp => Attribute.MaxXp;
    public override ILevelable CreateLevelable(Xp xp) => Levelable = new Attribute(xp);
}

public class WhenAddingXpToCharacter : WhenAddingXp
{
    #region Implementation

    protected override Xp MaxXp => Character.MaxXp;
    public override ILevelable CreateLevelable(Xp xp) => Levelable = new Character(xp: xp);

    #endregion

    #region Requirements

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void GivenBoostedRate_ThenXpIsClamped(ushort initial, ushort gained)
    {
        CreateLevelable(initial);
        (Levelable as Character).Equip(new ExpBooster());

        Leveler.Level(Levelable, gained);

        Levelable.Xp.Should().Be((ushort) (initial + gained * 2));
    }

    #endregion
}
