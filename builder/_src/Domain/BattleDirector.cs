namespace DesignPatterns.Builder.Domain
{
    public class BattleDirector
    {
        #region Public Interface

        public void Build(IBattleBuilder builder)
        {
            builder
                .WithBattleSystem()
                .WithEnvironment()
                .WithParticipants()
                .WithProgressionSystem();
        }

        #endregion
    }
}
