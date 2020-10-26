namespace DesignPatterns.Builder.Domain.FinalFantasyX
{
    public class Battle : Domain.Battle
    {
        #region Core

        public Battle(IBattleBuilder builder) : base(builder)
        {
            Arena = builder.Arena;
            Mob = builder.Mob;
            Party = builder.Party;
        }

        #endregion

        #region Public Interface

        public Arena Arena { get; }
        public Mob Mob { get; }
        public Party Party { get; }

        #endregion
    }
}
