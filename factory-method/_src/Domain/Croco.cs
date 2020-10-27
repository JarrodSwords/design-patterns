namespace DesignPatterns.FactoryMethod.Domain
{
    /// <summary>
    ///     Concrete Creator
    /// </summary>
    public class Croco : Enemy
    {
        #region Core

        public Croco() : base(320)
        {
        }

        #endregion

        #region Public Interface

        public int WeirdMushrooms { get; } = 2;

        #endregion

        #region Protected Interface

        protected override IMove CreateNextMove()
        {
            if (HitPoints >= 100)
                return new Attack();

            if (WeirdMushrooms > 0)
                return new WeirdMushroom();

            return new BombToss();
        }

        #endregion
    }
}
