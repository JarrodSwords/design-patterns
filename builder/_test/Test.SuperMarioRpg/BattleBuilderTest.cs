using DesignPatterns.Builder.Domain;
using DesignPatterns.Builder.Domain.SuperMarioRpg;
using FluentAssertions;
using Xunit;
using Battle = DesignPatterns.Builder.Domain.SuperMarioRpg.Battle;

namespace DesignPatterns.Builder.Test.SuperMarioRpg
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
            battle.BattleSystem.Should().BeOfType<TraditionalTurnBasedBattle>();
            battle.Mob.Should().NotBeNull();
            battle.Party.Should().NotBeNull();
            battle.ProgressionSystem.Should().BeOfType<LevelBasedProgression>();
        }

        #endregion
    }
}
