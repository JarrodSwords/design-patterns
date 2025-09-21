using Jgs.ValueObjects;

namespace CharacterProgression;

/// <summary>
///     Represents experience points.
/// </summary>
public class Xp(uint value) : TinyType<uint>(value), IComparable<Xp>, IComparable
{
    public int CompareTo(object? obj)
    {
        if (obj is null)
            return 1;
        if (ReferenceEquals(this, obj))
            return 0;
        return obj is Xp other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Xp)}");
    }

    public int CompareTo(Xp? other) =>
        other is null
            ? 1
            : Value.CompareTo(other.Value);

    public static bool operator >(Xp? left, Xp? right) => Comparer<Xp>.Default.Compare(left, right) > 0;

    public static bool operator >=(Xp? left, Xp? right) => Comparer<Xp>.Default.Compare(left, right) >= 0;
    public static implicit operator Xp(uint source) => new(source);

    public static bool operator <(Xp? left, Xp? right) => Comparer<Xp>.Default.Compare(left, right) < 0;

    public static bool operator <=(Xp? left, Xp? right) => Comparer<Xp>.Default.Compare(left, right) <= 0;
}
