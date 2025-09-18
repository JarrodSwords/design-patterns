using FluentAssertions;

namespace CharacterProgression.Domain2.Composition;

public abstract class WhenAddingXp(ILevelable levelable)
{
    #region Setup

    protected readonly ILevelable Levelable = levelable;

    #endregion

    #region Implementation

    public abstract void GivenMaxXp_ThenXpIsNotAdded();
    public abstract void ThenXpIsClamped();

    #endregion

    #region Requirements

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void ThenXpIsAdded(ushort initial, ushort gained)
    {
        Levelable.Set(initial);

        Levelable.Add(gained);

        Levelable.Xp.Should().Be((ushort) (initial + gained));
    }

    #endregion

    public class GivenAttribute() : WhenAddingXp(new Attribute())
    {
        #region Requirements

        [Fact]
        public override void GivenMaxXp_ThenXpIsNotAdded()
        {
            Levelable.Set(Attribute.MaxXp);

            Levelable.Add(20);

            Levelable.Xp.Should().Be(Attribute.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            Levelable.Add(300);

            Levelable.Xp.Should().Be(Attribute.MaxXp);
        }

        #endregion
    }

    public class GivenCharacter() : WhenAddingXp(new Character())
    {
        #region Requirements

        [Theory]
        [InlineData(1, 5)]
        [InlineData(100, 20)]
        public void GivenBoostedRate_ThenXpIsClamped(ushort initial, ushort gained)
        {
            Levelable.Set(initial);
            (Levelable as Character).Equip(new ExpBooster());

            Levelable.Add(gained);

            Levelable.Xp.Should().Be((ushort) (initial + gained * 2));
        }

        [Fact]
        public override void GivenMaxXp_ThenXpIsNotAdded()
        {
            Levelable.Set(Character.MaxXp);

            Levelable.Add(20);

            Levelable.Xp.Should().Be(Character.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            Levelable.Add(10000);

            Levelable.Xp.Should().Be(Character.MaxXp);
        }

        #endregion
    }
}
