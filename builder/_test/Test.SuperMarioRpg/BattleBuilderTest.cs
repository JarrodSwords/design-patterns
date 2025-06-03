using CreationalPatterns.Builder.Domain.SuperMarioRpg;
using FluentAssertions;

namespace CreationalPatterns.Builder.Test.SuperMarioRpg
{
    public class BattleBuilderTest : BattleBuilderBaseTest
    {
        public BattleBuilderTest()
        {
            Builder = new BattleBuilder();
        }

        public BattleBuilder Builder { get; }

        public override void WhenConfiguringRandomEncounter_ReturnValidBattle()
        {
            Director.ConfigureRandomEncounter(Builder);

            var battle = Builder.Build();

            battle.Should().BeOfType<Battle>();
            battle.Arena.Should().NotBeNull();
            battle.BattleSystem.Should().BeOfType<TraditionalTurnBasedBattle>();
            battle.Mob.Should().NotBeNull();
            battle.Party.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<LevelBasedProgression>();
        }

        public override void WhenConfiguringTutorial_ReturnValidBattle()
        {
            Director.ConfigureTutorial(Builder);

            var battle = Builder.Build();

            battle.Should().BeOfType<Battle>();
            battle.Arena.Should().NotBeNull();
            battle.BattleSystem.Should().BeOfType<TraditionalTurnBasedBattle>();
            battle.Mob.Should().NotBeNull();
            battle.Party.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<NullLevelBasedProgression>();
        }
    }
}
