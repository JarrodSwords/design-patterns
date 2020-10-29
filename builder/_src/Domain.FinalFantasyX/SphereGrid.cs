namespace DesignPatterns.Builder.Domain.FinalFantasyX
{
    public class SphereGrid : IProgressionSystem
    {
        #region Core

        public SphereGrid(int nodes)
        {
            Nodes = nodes;
        }

        #endregion

        #region Public Interface

        public int Nodes { get; }

        #endregion
    }
}
