using DesignPatterns.Builder.Application;
using DesignPatterns.Builder.Domain;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.Builder
{
    public class EnemyFactoryTest
    {
        #region Test Methods

        [Fact]
        public void WhenCreatingGoomba_ReturnEnemyGoomba()
        {
            var service = new EnemyFactory();
            var goomba = service.CreateGoomba();

            goomba.Attack.Should().Be(3);
            goomba.HitPoints.Should().Be(16);
            goomba.Immunities.Should().Be(StatusEffects.None);
            goomba.Name.Should().Be("Goomba");
        }

        #endregion
    }
}
