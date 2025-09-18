using FluentAssertions;

namespace CharacterProgression.Domain3.AskingNotTelling;

public abstract class WhenAddingXp(ILevelable levelable)
{
    #region Setup

    private readonly XpService _xpService = new();

    protected readonly ILevelable Levelable = levelable;

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
        Levelable.Set(initial);

        _xpService.Add(Levelable, gained, GetMax());

        Levelable.Xp.Should().Be((ushort) (initial + gained));
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
            Levelable.Set(Attribute.MaxXp);

            _xpService.Add(Levelable, 20, Attribute.MaxXp);

            Levelable.Xp.Should().Be(Attribute.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            _xpService.Add(Levelable, 300, Attribute.MaxXp);

            Levelable.Xp.Should().Be(Attribute.MaxXp);
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
            Levelable.Set(initial);
            (Levelable as Character).Equip(new ExpBooster());

            _xpService.Add(Levelable, gained, Character.MaxXp);

            Levelable.Xp.Should().Be((ushort) (initial + gained * 2));
        }

        [Fact]
        public override void GivenMaxXp_ThenXpIsNotAdded()
        {
            Levelable.Set(Character.MaxXp);

            _xpService.Add(Levelable, 20, Character.MaxXp);

            Levelable.Xp.Should().Be(Character.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            _xpService.Add(Levelable, 10000, Character.MaxXp);

            Levelable.Xp.Should().Be(Character.MaxXp);
        }

        #endregion
    }
}
