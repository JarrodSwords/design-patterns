namespace CharacterProgression.Domain7.Encapsulation;

public class Calculator
{
    private static readonly Dictionary<Level, Xp> Boundaries = new();

    static Calculator()
    {
        GenerateLevels();
    }

    private static void GenerateLevels()
    {
        var current = 0d;

        Boundaries[1] = (uint) current;

        for (byte i = 1; i < 100; i++)
        {
            current += (uint) Math.Floor(i + 300 * Math.Pow(2.0, i / 7.0));
            Boundaries[(Level) (i + 1)] = (uint) Math.Floor(current / 4.0);
        }
    }

    public static Level GetLevel(Xp xp)
    {
        var index = Array.BinarySearch(Boundaries.Values.ToArray(), xp);

        if (index < 0)
            index = ~index - 1;

        return Boundaries.Keys.ToList()[index];
    }
}
