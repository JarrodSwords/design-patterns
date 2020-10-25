namespace DesignPatterns.Builder.Domain
{
    /// <summary>
    ///     Concrete Builder
    /// </summary>
    public class ToughEnemyBuilder : EnemyBuilder
    {
        #region Public Interface

        public override IEnemyBuilder WithImmunities(StatusEffects immunities)
        {
            return base.WithImmunities(immunities | StatusEffects.Minor);
        }

        #endregion
    }
}
