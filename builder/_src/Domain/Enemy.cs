namespace DesignPatterns.Builder.Domain
{
    public class Enemy
    {
        #region Core

        public Enemy(IEnemyBuilder builder)
        {
            Attack = builder.Attack;
            HitPoints = builder.HitPoints;
            Immunities = builder.Immunities;
            Name = builder.Name;
        }

        #endregion

        #region Public Interface

        public int Attack { get; }
        public int HitPoints { get; }
        public StatusEffects Immunities { get; }
        public string Name { get; }

        #endregion
    }
}
