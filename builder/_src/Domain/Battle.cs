namespace DesignPatterns.Builder.Domain
{
    public abstract class Battle
    {
        #region Core

        protected Battle(IBattleBuilder builder)
        {
            BattleSystem = builder.BattleSystem;
            ProgressionSystem = builder.ProgressionSystem;
        }

        #endregion

        #region Public Interface

        public IBattleSystem BattleSystem { get; }
        public IProgressionSystem ProgressionSystem { get; }

        #endregion
    }
}
