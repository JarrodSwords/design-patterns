namespace DesignPatterns.Builder.Domain.FinalFantasyX
{
    public interface IBattleBuilder : Domain.IBattleBuilder
    {
        Arena Arena { get; }
        Mob Mob { get; }
        Party Party { get; }
    }
}
