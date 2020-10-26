namespace DesignPatterns.Builder.Domain
{
    /// <summary>
    ///     Builder
    /// </summary>
    public interface IBattleBuilder
    {
        IBattleBuilder WithBattleSystem();
        IBattleBuilder WithEnvironment();
        IBattleBuilder WithParticipants();
        IBattleBuilder WithProgressionSystem();
    }
}
