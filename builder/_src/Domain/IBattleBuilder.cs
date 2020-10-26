namespace DesignPatterns.Builder.Domain
{
    /// <summary>
    ///     Builder
    /// </summary>
    public interface IBattleBuilder
    {
        IBattleSystem BattleSystem { get; }
        IProgressionSystem ProgressionSystem { get; }
        IBattleBuilder WithBattleSystem();
        IBattleBuilder WithEnvironment();
        IBattleBuilder WithParticipants();
        IBattleBuilder WithProgressionSystem();
    }
}
