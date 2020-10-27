namespace DesignPatterns.FactoryMethod.Domain
{
    /// <summary>
    ///     Concrete Creator
    /// </summary>
    public class Jinx : Enemy
    {
        #region Core

        public Jinx() : base(600)
        {
        }

        #endregion

        #region Public Interface

        public bool HasUsedValorUp { get; private set; }

        #endregion

        #region Protected Interface

        protected override IMove CreateNextMove()
        {
            return HitPoints < 300 && !HasUsedValorUp
                ? (IMove) new ValorUp()
                : new TripleKick();
        }

        #endregion
    }
}
