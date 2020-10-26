using System.Collections.Generic;

namespace DesignPatterns.Builder.Domain.Osrs
{
    /// <summary>
    ///     Product
    /// </summary>
    public class Battle : Domain.Battle
    {
        #region Core

        public Battle(IBattleBuilder builder)
            : base(builder)
        {
            AggroedEnemies = builder.AggroedEnemies;
            Map = builder.Map;
            Player = builder.Player;
        }

        #endregion

        #region Public Interface

        public ICollection<Enemy> AggroedEnemies { get; }
        public Map Map { get; }
        public Player Player { get; }

        #endregion
    }
}
