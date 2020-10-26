using FluentAssertions;
using Xunit;

namespace DesignPatterns.FactoryMethod
{
    public class HammerBroTest
    {
        #region Test Methods

        [Fact]
        public void WhenQueueingNextAttack_WhenHealthy_NextSpecialAttackIsHammerTime()
        {
            var hammerBro = new HammerBro();

            hammerBro.NextAttack.Should().BeOfType<HammerTime>();
        }

        [Fact]
        public void WhenQueueingNextAttack_WhenHurt_NextSpecialAttackIsValorUp()
        {
            var hammerBro = new HammerBro();
            var mario = new Mario();

            mario.Attack(hammerBro);

            hammerBro.NextAttack.Should().BeOfType<ValorUp>();
        }

        #endregion
    }

    public class Mario
    {
        #region Public Interface

        public void Attack(Enemy enemy)
        {
            enemy.ReceiveAttack();
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

        public void ReceiveAttack()
        {
            IsHurt = true;
        }

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
