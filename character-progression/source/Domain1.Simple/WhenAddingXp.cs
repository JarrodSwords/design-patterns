using FluentAssertions;

namespace CharacterProgression.Domain1.Simple;

public abstract class WhenAddingXp(IProgressable progressable)
{
    #region Setup

    protected readonly IProgressable Progressable = progressable;

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
    }

    public class GivenCharacter() : WhenAddingXp(new Character())
    {
    }
}
