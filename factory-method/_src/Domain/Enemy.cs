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

        public IMove NextMove
        {
            get => _nextMove ??= CreateNextMove();
            private set => _nextMove = value;
        }

        public void ReceiveDamage(int damage)
        {
            HitPoints -= damage;
            NextMove = CreateNextMove();
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
