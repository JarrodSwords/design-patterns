using FluentAssertions;

namespace CharacterProgression.Domain3.AskingNotTelling;

public abstract class WhenAddingXp(ILevelable levelable)
{
    #region Setup

    protected readonly ILevelable Levelable = levelable;
    protected readonly XpService XpService = new();

    #endregion

    #region Implementation

    protected abstract Xp MaxXp { get; }

    #endregion

    #region Requirements

    [Fact]
    public void GivenMaxXp_ThenXpIsNotAdded()
    {
        Levelable.Set(MaxXp);

        XpService.Add(Levelable, 10, MaxXp);

        Levelable.Xp.Should().Be(MaxXp);
    }

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void ThenXpIsAdded(uint initial, uint gained)
    {
        Levelable.Set(initial);

        XpService.Add(Levelable, gained, MaxXp);

        Levelable.Xp.Should().Be(initial + gained);
    }

    [Fact]
    public void ThenXpIsClamped()
    {
        Levelable.Set(MaxXp - 10);

        XpService.Add(Levelable, 20, MaxXp);

        Levelable.Xp.Should().Be(MaxXp);
    }

    #endregion
}

public class WhenAddingXpToAttribute() : WhenAddingXp(new Attribute())
{
    protected override Xp MaxXp => Attribute.MaxXp;
}

public class WhenAddingXpToCharacter() : WhenAddingXp(new Character())
{
    #region Implementation

    protected override Xp MaxXp => Character.MaxXp;

    #endregion

    #region Requirements

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void GivenBoostedRate_ThenXpIsClamped(uint initial, uint gained)
    {
        Levelable.Set(initial);
        (Levelable as Character).Equip(new ExpBooster());

        XpService.Add(Levelable, gained, MaxXp);

        Levelable.Xp.Should().Be(initial + gained * 2);
    }

    #endregion
}
