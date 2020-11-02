using DesignPatterns.Builder.Domain.Osrs;
using FluentAssertions;

namespace DesignPatterns.Builder.Test.Osrs
{
    public class BattleBuilderTest : BattleBuilderBaseTest
    {
        #region Core

        public BattleBuilderTest()
        {
            Builder = new BattleBuilder();
        }

        #endregion

        #region Public Interface

        public BattleBuilder Builder { get; }

        #endregion

        #region Test Methods

        public override void WhenConfiguringRandomEncounter_ReturnValidBattle()
        {
            Director.Build(Builder);

            var battle = Builder.Build();
                
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
