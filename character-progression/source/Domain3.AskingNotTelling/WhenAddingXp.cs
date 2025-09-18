using FluentAssertions;

namespace CharacterProgression.Domain3.AskingNotTelling;

public abstract class WhenAddingXp(IProgressable progressable)
{
    #region Setup

    private readonly XpService _xpService = new();

    protected readonly IProgressable Progressable = progressable;

    #endregion

    #region Implementation

    public abstract Xp GetMax();
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

        _xpService.Add(Progressable, gained, GetMax());

        Progressable.Xp.Should().Be((ushort) (initial + gained));
    }

    #endregion

    public class GivenAttribute() : WhenAddingXp(new Attribute())
    {
        #region Implementation

        public override Xp GetMax() => Attribute.MaxXp;

        #endregion

        #region Requirements

        [Fact]
        public override void GivenMaxXp_ThenXpIsNotAdded()
        {
            Progressable.Set(Attribute.MaxXp);

            _xpService.Add(Progressable, 20, Attribute.MaxXp);

            Progressable.Xp.Should().Be(Attribute.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            _xpService.Add(Progressable, 300, Attribute.MaxXp);

            Progressable.Xp.Should().Be(Attribute.MaxXp);
        }

        #endregion
    }

    public class GivenCharacter() : WhenAddingXp(new Character())
    {
        #region Implementation

        public override Xp GetMax() => Character.MaxXp;

        #endregion

        #region Requirements

        [Theory]
        [InlineData(1, 5)]
        [InlineData(100, 20)]
        public void GivenBoostedRate_ThenXpIsClamped(ushort initial, ushort gained)
        {
            Progressable.Set(initial);
            (Progressable as Character).Equip(new ExpBooster());

            _xpService.Add(Progressable, gained, Character.MaxXp);

            Progressable.Xp.Should().Be((ushort) (initial + gained * 2));
        }

        [Fact]
        public override void GivenMaxXp_ThenXpIsNotAdded()
        {
            Progressable.Set(Character.MaxXp);

            _xpService.Add(Progressable, 20, Character.MaxXp);

            Progressable.Xp.Should().Be(Character.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            _xpService.Add(Progressable, 10000, Character.MaxXp);

            Progressable.Xp.Should().Be(Character.MaxXp);
        }

        #endregion
    }
}
