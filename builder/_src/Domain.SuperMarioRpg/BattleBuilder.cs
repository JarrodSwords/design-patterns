namespace DesignPatterns.Builder.Domain.SuperMarioRpg
{
    /// <summary>
    ///     Concrete Builder
    /// </summary>
    public class BattleBuilder : IBattleBuilder
    {
        #region Public Interface

        public Battle Build()
        {
            return new Battle(this);
        }

        #endregion

        #region IBattleBuilder

        public Arena Arena { get; private set; }
        public IBattleSystem BattleSystem { get; private set; }
        public Mob Mob { get; private set; }

        public Party Party { get; private set; }
        public IProgressionSystem ProgressionSystem { get; private set; }

        public Domain.IBattleBuilder WithBattleSystem()
        {
            BattleSystem = new TraditionalTurnBasedBattle();
            return this;
        }

        public Domain.IBattleBuilder WithEnvironment()
        {
            Arena = new Arena();
            return this;
        }

        public Domain.IBattleBuilder WithParticipants()
        {
            Mob = new Mob();
            Party = new Party();
            return this;
        }

        public Domain.IBattleBuilder WithProgressionSystem()
        {
            ProgressionSystem = new LevelBasedProgression();
            return this;
        }

        #endregion
    }
}
