namespace CreationalPatterns.Builder.Domain.SuperMarioRpg
{
    /// <summary>
    ///     Product
    /// </summary>
    public class Battle
    {
        public Battle(IBattleBuilder builder)
        {
            Arena = builder.Arena;
            BattleSystem = builder.BattleSystem;
            Mob = builder.Mob;
            Party = builder.Party;
            ProgressionSystem = builder.ProgressionSystem;
        }

        public Arena Arena { get; }
        public IBattleSystem BattleSystem { get; }
        public Mob Mob { get; }
        public Party Party { get; }
        public IProgressionSystem ProgressionSystem { get; }
    }
}
