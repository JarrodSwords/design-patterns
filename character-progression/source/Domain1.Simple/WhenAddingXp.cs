using FluentAssertions;

namespace CharacterProgression.Domain1.Simple;

public abstract class WhenAddingXp(IProgressable progressable)
{
    #region Setup

    protected readonly IProgressable Progressable = progressable;

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
        Progressable.Set(initial);

        Progressable.Add(gained);

        Progressable.Xp.Should().Be((ushort) (initial + gained));
    }

    #endregion

    public class GivenAttribute() : WhenAddingXp(new Attribute())
    {
        #region Requirements

        [Fact]
        public override void GivenMaxXp_ThenXpIsNotAdded()
        {
            Progressable.Set(Attribute.MaxXp);

            Progressable.Add(20);

            Progressable.Xp.Should().Be(Attribute.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            Progressable.Add(300);

            Progressable.Xp.Should().Be(Attribute.MaxXp);
        }

        #endregion
    }

    public class GivenCharacter() : WhenAddingXp(new Character())
    {
        #region Requirements

        [Fact]
        public override void GivenMaxXp_ThenXpIsNotAdded()
        {
            Progressable.Set(Character.MaxXp);

            Progressable.Add(20);

            Progressable.Xp.Should().Be(Character.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            Progressable.Add(10000);

            Progressable.Xp.Should().Be(Character.MaxXp);
        }

        #endregion
    }
}
