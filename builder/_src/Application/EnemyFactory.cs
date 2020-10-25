using DesignPatterns.Builder.Domain;

namespace DesignPatterns.Builder.Application
{
    /// <summary>
    ///     Director
    /// </summary>
    public class EnemyFactory
    {
        #region Public Interface

        public Enemy CreateGoomba()
        {
            var builder = new EnemyBuilder();
            var goomba = builder
                .WithAttack(3)
                .WithHitPoints(16)
                .WithName("Goomba")
                .Build();

            return goomba;
        }

        #endregion
    }
}
