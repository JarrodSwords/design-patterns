namespace CreationalPatterns.FactoryMethod.Domain
{
    /// <summary>
    ///     Concrete Creator
    /// </summary>
    public class Croco : Enemy
    {
        public Croco() : base(320)
        {
        }

        public int WeirdMushrooms { get; } = 2;

        protected override IMove CreateNextMove()
        {
            if (HitPoints >= 100)
                return new Attack();

            if (WeirdMushrooms > 0)
                return new WeirdMushroom();

            return new BombToss();
        }
    }
}
