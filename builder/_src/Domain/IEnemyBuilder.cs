namespace DesignPatterns.Builder.Domain
{
    public interface IEnemyBuilder : IBuilder<Enemy>
    {
        int Attack { get; }
        int HitPoints { get; }
        StatusEffects Immunities { get; }
        string Name { get; }
        IEnemyBuilder WithAttack(int attack);
        IEnemyBuilder WithHitPoints(int hitPoints);
        IEnemyBuilder WithImmunities(StatusEffects immunities);
        IEnemyBuilder WithName(string name);
    }
}
