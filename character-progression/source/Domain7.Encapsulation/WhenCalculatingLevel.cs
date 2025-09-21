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
    public void Then(uint xp, byte expected)
    {
        var level = Calculator.GetLevel(xp);

        level.Should().Be(expected);
    }

    #endregion
}

public class Calculator
{
    private static readonly Dictionary<Level, Xp> _boundaries = new();

    static Calculator()
    {
        GenerateLevels();
    }

    private static void GenerateLevels()
    {
        var current = 0d;

        _boundaries[1] = (uint) current;

        for (byte i = 1; i < 100; i++)
        {
            current += (uint) Math.Floor(i + 300 * Math.Pow(2.0, i / 7.0));
            _boundaries[(Level) (i + 1)] = (uint) Math.Floor(current / 4.0);
        }
    }

    public static Level GetLevel(Xp xp)
    {
        var index = Array.BinarySearch(_boundaries.Values.ToArray(), xp);

        if (index < 0)
            index = ~index - 1;

        return _boundaries.Keys.ToList()[index];
    }
}
