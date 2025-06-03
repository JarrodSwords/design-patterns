using CreationalPatterns.Builder.Domain.Osrs;
using FluentAssertions;

namespace CreationalPatterns.Builder.Test.Osrs
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
            battle.AggroedEnemies.Should().NotBeNull();
            battle.BattleSystem.Should().BeOfType<RealTimeBattle>();
            battle.Map.Should().NotBeNull();
            battle.Player.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<ActivityBasedProgression>();
        }

        public override void WhenConfiguringTutorial_ReturnValidBattle()
        {
            Director.ConfigureTutorial(Builder);

            var battle = Builder.Build();

            battle.Should().BeOfType<Battle>();
            battle.AggroedEnemies.Should().NotBeNull();
            battle.BattleSystem.Should().BeOfType<RealTimeBattle>();
            battle.Map.Should().NotBeNull();
            battle.Player.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<NullActivityBasedProgression>();
        }
    }
}
