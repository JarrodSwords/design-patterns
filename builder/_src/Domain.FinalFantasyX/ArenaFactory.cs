namespace DesignPatterns.Builder.Domain.FinalFantasyX
{
    public class ArenaFactory
    {
        #region Public Interface

        public Arena Create()
        {
            return new Arena();
        }

        #endregion
    }
}
