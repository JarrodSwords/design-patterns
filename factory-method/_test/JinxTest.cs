using DesignPatterns.FactoryMethod.Domain;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.FactoryMethod
{
    public class JinxTest
    {
        #region Core

        private readonly Jinx _jinx;

        public JinxTest()
        {
            _jinx = new Jinx();
        }

        #endregion

        #region Test Methods

        [Fact]
        public void WhenQueueingNextMove_WhenHealthy_NextMoveIsTripleKick()
        {
            _jinx.NextMove.Should().BeOfType<TripleKick>();
        }

        [Fact]
        public void WhenQueueingNextMove_WithFewerThan300HitPoints_NextMoveIsValorUp()
        {
            var mario = new Mario();
            mario.Attack(_jinx, 301);

            _jinx.NextMove.Should().BeOfType<ValorUp>();
        }

        #endregion
    }
}
