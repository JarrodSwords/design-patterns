namespace CreationalPatterns.Builder.Domain
{
    /// <summary>
    ///     Director
    /// </summary>
    public class BattleDirector
    {
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
    }
}
