using System.Collections.Generic;

namespace DesignPatterns.Builder.Domain.Osrs
{
    /// <summary>
    ///     Product
    /// </summary>
    public class Battle
    {
        #region Core

        public Battle(IBattleBuilder builder)
        {
            AggroedEnemies = builder.AggroedEnemies;
            BattleSystem = builder.BattleSystem;
            Map = builder.Map;
            Player = builder.Player;
            ProgressionSystem = builder.ProgressionSystem;
        }

        #endregion

        #region Public Interface

        public ICollection<Enemy> AggroedEnemies { get; }
        public IBattleSystem BattleSystem { get; }
        public Map Map { get; }
        public Player Player { get; }
        public IProgressionSystem ProgressionSystem { get; }

        #endregion
    }
}
