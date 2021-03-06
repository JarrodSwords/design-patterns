﻿using DesignPatterns.Builder.Domain;
using DesignPatterns.Builder.Domain.Osrs;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.Builder.Test.Osrs
{
    public class BattleBuilderTest
    {
        #region Test Methods

        [Fact]
        public void WhenBuildingBattle_ReturnValidBattle()
        {
            var builder = new BattleBuilder();
            var director = new BattleDirector();
            director.Build(builder);

            var battle = builder.Build();

            battle.Should().BeOfType<Battle>();
            battle.AggroedEnemies.Should().NotBeNull();
            battle.BattleSystem.Should().BeOfType<RealTimeBattle>();
            battle.Map.Should().NotBeNull();
            battle.Player.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<ActivityBasedProgression>();
        }

        #endregion
    }
}
