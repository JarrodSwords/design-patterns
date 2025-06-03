using System.Collections.Generic;

namespace CreationalPatterns.Builder.Domain.Osrs
{
    /// <summary>
    ///     Product
    /// </summary>
    public class Battle
    {
        public Battle(IBattleBuilder builder)
        {
            AggroedEnemies = builder.AggroedEnemies;
            BattleSystem = builder.BattleSystem;
            Map = builder.Map;
            Player = builder.Player;
            ProgressionSystem = builder.ProgressionSystem;
        }

        public ICollection<Enemy> AggroedEnemies { get; }
        public IBattleSystem BattleSystem { get; }
        public Map Map { get; }
        public Player Player { get; }
        public IProgressionSystem ProgressionSystem { get; }
    }
}
