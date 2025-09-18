using FluentAssertions;

namespace CharacterProgression.Domain1.Simple;

public abstract class WhenAddingXp(ILevelable levelable)
{
    #region Setup

    protected readonly ILevelable Levelable = levelable;

    #endregion

    #region Implementation

    protected abstract Xp MaxXp { get; }

    #endregion

    #region Requirements

    [Fact]
    public void GivenMaxXp_ThenXpIsNotAdded()
    {
        Levelable.Set(MaxXp);

        Levelable.Add(10);

        Levelable.Xp.Should().Be(MaxXp);
    }

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void ThenXpIsAdded(ushort initial, ushort gained)
    {
        Levelable.Set(initial);

        Levelable.Add(gained);

        Levelable.Xp.Should().Be((ushort) (initial + gained));
    }

    [Fact]
    public void ThenXpIsClamped()
    {
        Levelable.Set((Xp) (MaxXp - 10));

        Levelable.Add(20);

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
    protected override Xp MaxXp => Character.MaxXp;
}
