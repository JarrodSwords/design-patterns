using System.Collections.Generic;

namespace DesignPatterns.Builder.Domain.Osrs
{
    public interface IBattleBuilder : Domain.IBattleBuilder
    {
        ICollection<Enemy> AggroedEnemies { get; }
        Map Map { get; }
        Player Player { get; }
    }
}
