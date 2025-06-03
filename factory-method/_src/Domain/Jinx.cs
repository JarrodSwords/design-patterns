namespace CreationalPatterns.FactoryMethod.Domain
{
    /// <summary>
    ///     Concrete Creator
    /// </summary>
    public class Jinx : Enemy
    {
        public Jinx() : base(600)
        {
        }

        public bool HasUsedValorUp { get; private set; }

        protected override IMove CreateNextMove() =>
            HitPoints < 300 && !HasUsedValorUp
                ? (IMove) new ValorUp()
                : new TripleKick();
    }
}
