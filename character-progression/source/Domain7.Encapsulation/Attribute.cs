namespace CharacterProgression.Domain7.Encapsulation;

public class Attribute(Xp? xp = null) : ILevelable
{
    public static readonly Xp MaxXp = 255;
    private readonly Levelable _levelable = new(xp ?? 0, MaxXp);

    public Level Level => _levelable.Level;
    public Xp Xp => _levelable.Xp;
    public void Add(Xp xp) => _levelable.Add(xp);
}
