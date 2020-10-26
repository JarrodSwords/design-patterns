using DesignPatterns.Builder.Domain;
using DesignPatterns.Builder.Domain.FinalFantasyX;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.Builder.Test.FinalFantasyX
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
            battle.Arena.Should().NotBeNull();
            battle.BattleSystem.Should().BeOfType<ConditionalTurnBasedBattle>();
            battle.Mob.Should().NotBeNull();
            battle.Party.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<SphereGrid>();
        }

        #endregion
    }
}
