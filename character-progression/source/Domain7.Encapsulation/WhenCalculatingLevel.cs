using FluentAssertions;

namespace CharacterProgression.Domain7.Encapsulation;

public class WhenCalculatingLevelTable
{
    #region Requirements

    [Theory]
    [InlineData(0u, 1)]
    [InlineData(82u, 1)]
    [InlineData(83u, 2)]
    [InlineData(173u, 2)]
    [InlineData(174u, 3)]
    [InlineData(13034431u, 99)]
    public void ThenLevelIsExpected(uint xp, byte expected)
    {
        var level = Calculator.GetLevel(xp);

        level.Should().Be(expected);
    }

    #endregion
}
