using FluentAssertions;
using Xunit;

namespace DesignPatterns.FactoryMethod
{
    public class HammerBroTest
    {
        #region Test Methods

        [Fact]
        public void WhenQueueingNextAttack_WhenHealthy_NextAttackIsHammerTime()
        {
            var hammerBro = new HammerBro();

            hammerBro.NextAttack.Should().BeOfType<HammerTime>();
        }

        #endregion
    }

    /// <summary>
    ///     Creator
    /// </summary>
    public abstract class Enemy
    {
        #region Core

        private SpecialAttack _nextAttack;

        #endregion

        #region Public Interface

        public bool IsHurt { get; private set; }
        public SpecialAttack NextAttack => _nextAttack ??= CreateSpecialAttack();

        #endregion

        #region Protected Interface

        protected abstract SpecialAttack CreateSpecialAttack();

        #endregion
    }

    /// <summary>
    ///     Concrete Creator
    /// </summary>
    public class HammerBro : Enemy
    {
        #region Protected Interface

        protected override SpecialAttack CreateSpecialAttack()
        {
            return IsHurt
                ? (SpecialAttack) new ValorUp()
                : new HammerTime();
        }

        #endregion
    }

    /// <summary>
    ///     Concrete Creator
    /// </summary>
    public class Toadstool2 : Enemy
    {
        #region Protected Interface

        protected override SpecialAttack CreateSpecialAttack()
        {
            return IsHurt
                ? (SpecialAttack) new MegaRecover()
                : new Recover();
        }

        #endregion
    }

    /// <summary>
    ///     Product
    /// </summary>
    public abstract class SpecialAttack
    {
    }

    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class HammerTime : SpecialAttack
    {
    }

    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class ValorUp : SpecialAttack
    {
    }

    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class Recover : SpecialAttack
    {
    }

    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class MegaRecover : SpecialAttack
    {
    }
}
