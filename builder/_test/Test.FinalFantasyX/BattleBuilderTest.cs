using CreationalPatterns.Builder.Domain.FinalFantasyX;
using FluentAssertions;

namespace CreationalPatterns.Builder.Test.FinalFantasyX
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
            battle.BattleSystem.Should().BeOfType<ConditionalTurnBasedBattle>();
            battle.Mob.Should().NotBeNull();
            battle.Party.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<SphereGrid>();
        }

        public override void WhenConfiguringTutorial_ReturnValidBattle()
        {
            Director.ConfigureTutorial(Builder);

            var battle = Builder.Build();

            battle.Should().BeOfType<Battle>();
            battle.Arena.Should().NotBeNull();
            battle.BattleSystem.Should().BeOfType<ConditionalTurnBasedBattle>();
            battle.Mob.Should().NotBeNull();
            battle.Party.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<NullSphereGrid>();
        }
    }
}
