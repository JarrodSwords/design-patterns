namespace DesignPatterns.Builder.Domain
{
    public class EnemyBuilder : IEnemyBuilder
    {
        #region IEnemyBuilder

        public int Attack { get; protected set; }
        public int HitPoints { get; protected set; }
        public StatusEffects Immunities { get; protected set; }
        public string Name { get; protected set; }

        public Enemy Build()
        {
            return new Enemy(this);
        }

        public IEnemyBuilder WithAttack(int attack)
        {
            Attack = attack;
            return this;
        }

        public IEnemyBuilder WithHitPoints(int hitPoints)
        {
            HitPoints = hitPoints;
            return this;
        }

        public virtual IEnemyBuilder WithImmunities(StatusEffects immunities)
        {
            Immunities |= immunities;
            return this;
        }

        public IEnemyBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        #endregion
    }
}
