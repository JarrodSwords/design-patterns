namespace DesignPatterns.Builder.Domain.SuperMarioRpg
{
    /// <summary>
    ///     Product
    /// </summary>
    public class Battle
    {
        #region Core

        public Battle(IBattleBuilder builder)
        {
            Arena = builder.Arena;
            BattleSystem = builder.BattleSystem;
            Mob = builder.Mob;
            Party = builder.Party;
            ProgressionSystem = builder.ProgressionSystem;
        }

        #endregion

        #region Public Interface

        public Arena Arena { get; }
        public IBattleSystem BattleSystem { get; }
        public Mob Mob { get; }
        public Party Party { get; }
        public IProgressionSystem ProgressionSystem { get; }

        #endregion
    }
}
