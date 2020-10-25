namespace DesignPatterns.AbstractFactory.Domain
{
    public class Contract
    {
        #region Core

        public Contract(Source source)
        {
            Source = source;
        }

        #endregion

        #region Public Interface

        public Source Source { get; }

        #endregion
    }
}
