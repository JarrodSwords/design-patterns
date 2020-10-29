namespace DesignPatterns.Builder.Domain.FinalFantasyX
{
    /// <summary>
    ///     Concrete Builder
    /// </summary>
    public class BattleBuilder : IBattleBuilder
    {
        #region Core

        private readonly ArenaFactory _arenaFactory;
        private readonly int _nodes;

        public BattleBuilder(ArenaFactory arenaFactory, int nodes)
        {
            _arenaFactory = arenaFactory;
            _nodes = nodes;
        }

        #endregion

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
            BattleSystem = new ConditionalTurnBasedBattle();
            return this;
        }

        public Domain.IBattleBuilder WithEnvironment()
        {
            Arena = _arenaFactory.Create();
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
            ProgressionSystem = new SphereGrid(_nodes);
            return this;
        }

        #endregion
    }
}
