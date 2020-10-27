namespace DesignPatterns.FactoryMethod.Domain
{
    /// <summary>
    ///     Creator
    /// </summary>
    public abstract class Enemy
    {
        #region Core

        private IMove _nextMove;

        protected Enemy(int hitPoints)
        {
            HitPoints = hitPoints;
        }

        #endregion

        #region Public Interface

        public int HitPoints { get; private set; }
        public IMove NextMove => _nextMove ??= CreateNextMove();

        public void ReceiveDamage(int damage)
        {
            HitPoints -= damage;
        }

        #endregion

        #region Protected Interface

        /// <summary>
        ///     Factory Method
        /// </summary>
        /// <returns>Product</returns>
        protected abstract IMove CreateNextMove();

        #endregion
    }
}
