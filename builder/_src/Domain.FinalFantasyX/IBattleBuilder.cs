namespace DesignPatterns.Builder.Domain.FinalFantasyX
{
    public interface IBattleBuilder : Domain.IBattleBuilder
    {
        Arena Arena { get; }
        IBattleSystem BattleSystem { get; }
        Mob Mob { get; }
        Party Party { get; }
        IProgressionSystem ProgressionSystem { get; }
    }
}
