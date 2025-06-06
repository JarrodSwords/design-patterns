﻿using System.Collections.Generic;

namespace CreationalPatterns.Builder.Domain.Osrs
{
    public interface IBattleBuilder : Domain.IBattleBuilder
    {
        ICollection<Enemy> AggroedEnemies { get; }
        IBattleSystem BattleSystem { get; }
        Map Map { get; }
        Player Player { get; }
        IProgressionSystem ProgressionSystem { get; }
    }
}
