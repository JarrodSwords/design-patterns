using DesignPatterns.FactoryMethod.Domain;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.FactoryMethod
{
    public class CrocoTest
    {
        #region Core

        private readonly Croco _croco;

        public CrocoTest()
        {
            _croco = new Croco();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenQueueingNextMove_WhenHealthy_NextMoveIsAttack()
        {
            _croco.NextMove.Should().BeOfType<Attack>();
        }

        [Fact]
        public void WhenQueueingNextMove_WithFewerThan100HitPoints_NextMoveIsWeirdMushroom()
        {
            var mario = new Mario();
            mario.Attack(_croco, 221);

            _croco.NextMove.Should().BeOfType<WeirdMushroom>();
        }

        #endregion
    }
}
