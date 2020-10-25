using DesignPatterns.Builder.Application;
using DesignPatterns.Builder.Domain;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.Builder
{
    public class EnemyFactoryTest
    {
        #region Core

        private readonly EnemyFactory _service;

        public EnemyFactoryTest()
        {
            _service = new EnemyFactory();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenCreatingCroco_ReturnEnemyCroco()
        {
            var croco = _service.CreateCroco();

            croco.Attack.Should().Be(25);
            croco.HitPoints.Should().Be(320);
            croco.Immunities.Should().Be(StatusEffects.Minor);
            croco.Name.Should().Be("Croco");
        }

        [Fact]
        public void WhenCreatingGoomba_ReturnEnemyGoomba()
        {
            var goomba = _service.CreateGoomba();

            goomba.Attack.Should().Be(3);
            goomba.HitPoints.Should().Be(16);
            goomba.Immunities.Should().Be(StatusEffects.None);
            goomba.Name.Should().Be("Goomba");
        }

        [Fact]
        public void WhenCreatingMack_ReturnEnemyMack()
        {
            var mack = _service.CreateMack();

            mack.Attack.Should().Be(22);
            mack.HitPoints.Should().Be(480);
            mack.Immunities.Should().Be(StatusEffects.All);
            mack.Name.Should().Be("Mack");
        }

        #endregion
    }
}
