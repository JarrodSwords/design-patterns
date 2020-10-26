namespace DesignPatterns.Builder.Domain.SuperMarioRpg
{
    public interface IBattleBuilder : Domain.IBattleBuilder
    {
        Arena Arena { get; }
        Mob Mob { get; }
        Party Party { get; }
    }
}
