namespace DesignPatterns.Builder.Domain
{
    /// <summary>
    ///     Concrete Builder
    /// </summary>
    public class BossBuilder : EnemyBuilder
    {
        #region Public Interface

        public override IEnemyBuilder WithImmunities(StatusEffects immunities)
        {
            return base.WithImmunities(StatusEffects.All);
        }

        #endregion
    }
}
