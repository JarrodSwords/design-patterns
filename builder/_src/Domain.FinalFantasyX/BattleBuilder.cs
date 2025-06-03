namespace CreationalPatterns.Builder.Domain.FinalFantasyX
{
    /// <summary>
    ///     Concrete Builder
    /// </summary>
    public class BattleBuilder : IBattleBuilder
    {
        private IProgressionSystem _progressionSystem;

        public Battle Build() => new Battle(this);

        public Arena Arena { get; private set; }
        public IBattleSystem BattleSystem { get; private set; }
        public Mob Mob { get; private set; }
        public Party Party { get; private set; }

        public IProgressionSystem ProgressionSystem
        {
            get => _progressionSystem ??= new NullSphereGrid();
            private set => _progressionSystem = value;
        }

        public Domain.IBattleBuilder WithBattleSystem()
        {
            BattleSystem = new ConditionalTurnBasedBattle();
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
            ProgressionSystem = new SphereGrid();
            return this;
        }
    }
}
