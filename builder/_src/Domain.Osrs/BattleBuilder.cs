using System.Collections.Generic;

namespace DesignPatterns.Builder.Domain.Osrs
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

        public ICollection<Enemy> AggroedEnemies { get; private set; }
        public IBattleSystem BattleSystem { get; private set; }
        public Map Map { get; private set; }
        public Player Player { get; private set; }
        public IProgressionSystem ProgressionSystem { get; private set; }

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

        #endregion
    }
}
