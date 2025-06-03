using System.Collections.Generic;

namespace CreationalPatterns.Builder.Domain.Osrs
{
    /// <summary>
    ///     Concrete Builder
    /// </summary>
    public class BattleBuilder : IBattleBuilder
    {
        private IProgressionSystem _progressionSystem;

        public Battle Build() => new Battle(this);

        public ICollection<Enemy> AggroedEnemies { get; private set; }
        public IBattleSystem BattleSystem { get; private set; }
        public Map Map { get; private set; }
        public Player Player { get; private set; }

        public IProgressionSystem ProgressionSystem
        {
            get => _progressionSystem ??= new NullActivityBasedProgression();
            private set => _progressionSystem = value;
        }

        public Domain.IBattleBuilder WithBattleSystem()
        {
            BattleSystem = new RealTimeBattle();
            return this;
        }

        public Domain.IBattleBuilder WithEnvironment()
        {
            Map = new Map();
            return this;
        }

        public Domain.IBattleBuilder WithParticipants()
        {
            AggroedEnemies = new List<Enemy>();
            Player = new Player();
            return this;
        }

        public Domain.IBattleBuilder WithProgressionSystem()
        {
            ProgressionSystem = new ActivityBasedProgression();
            return this;
        }
    }
}
