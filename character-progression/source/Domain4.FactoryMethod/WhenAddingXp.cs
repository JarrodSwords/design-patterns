using FluentAssertions;

namespace CharacterProgression.Domain4.FactoryMethod;

public abstract class WhenAddingXp
{
    #region Setup

    private readonly Leveler _leveler = new();
    protected ILevelable Levelable;

    #endregion

    #region Implementation

    public abstract ILevelable CreateLevelable(Xp xp);
    public abstract void GivenMaxXp_ThenXpIsNotAdded();
    public abstract void ThenXpIsClamped();

    #endregion

    #region Requirements

    [Theory]
    [InlineData(1, 5)]
    [InlineData(100, 20)]
    public void ThenXpIsAdded(ushort initial, ushort gained)
    {
        CreateLevelable(initial);

        _leveler.Level(Levelable, gained);

        Levelable.Xp.Should().Be((ushort) (initial + gained));
    }

    #endregion

    public class GivenAttribute : WhenAddingXp
    {
        #region Implementation

        public Attribute Attribute => Levelable as Attribute;
        public override ILevelable CreateLevelable(Xp xp) => Levelable = new Attribute(xp);

        #endregion

        #region Requirements

        [Fact]
        public override void GivenMaxXp_ThenXpIsNotAdded()
        {
            CreateLevelable(Attribute.MaxXp);

            _leveler.Level(Attribute, 20);

            Attribute.Xp.Should().Be(Attribute.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            CreateLevelable(Attribute.MaxXp);

            _leveler.Level(Levelable, 300);

            Attribute.Xp.Should().Be(Attribute.MaxXp);
        }

        #endregion
    }

    public class GivenCharacter : WhenAddingXp
    {
        #region Implementation

        public Character Character => Levelable as Character;
        public override ILevelable CreateLevelable(Xp xp) => Levelable = new Character(xp: xp);

        #endregion

        #region Requirements

        [Theory]
        [InlineData(1, 5)]
        [InlineData(100, 20)]
        public void GivenBoostedRate_ThenXpIsClamped(ushort initial, ushort gained)
        {
            CreateLevelable(initial);
            Character.Equip(new ExpBooster());

            _leveler.Level(Character, gained);

            Character.Xp.Should().Be((ushort) (initial + gained * 2));
        }

        [Fact]
        public override void GivenMaxXp_ThenXpIsNotAdded()
        {
            CreateLevelable(Character.MaxXp);

            _leveler.Level(Character, 20);

            Character.Xp.Should().Be(Character.MaxXp);
        }

        [Fact]
        public override void ThenXpIsClamped()
        {
            CreateLevelable(Character.MaxXp);

            _leveler.Level(Character, 10000);

            Character.Xp.Should().Be(Character.MaxXp);
        }

        #endregion
    }
}
