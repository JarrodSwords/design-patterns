using DesignPatterns.Builder.Domain.FinalFantasyX;

namespace DesignPatterns.Builder.Domain
{
    /// <summary>
    ///     Director
    /// </summary>
    public class BattleDirector
    {
        #region Public Interface

        public void ConfigureRandomEncounter(IBattleBuilder builder)
        {
            builder
                .WithBattleSystem()
                .WithEnvironment()
                .WithParticipants()
                .WithProgressionSystem();
        }

        public void ConfigureTutorial(IBattleBuilder builder)
        {
            builder
                .WithBattleSystem()
                .WithEnvironment()
                .WithParticipants();
        }

        #endregion
    }
}
