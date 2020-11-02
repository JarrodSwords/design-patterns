using DesignPatterns.Builder.Domain.SuperMarioRpg;
using FluentAssertions;

namespace DesignPatterns.Builder.Test.SuperMarioRpg
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
            battle.Arena.Should().NotBeNull();
            battle.BattleSystem.Should().BeOfType<TraditionalTurnBasedBattle>();
            battle.Mob.Should().NotBeNull();
            battle.Party.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<LevelBasedProgression>();
        }

        #endregion
    }
}
