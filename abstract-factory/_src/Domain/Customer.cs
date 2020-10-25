using DesignPatterns.AbstractFactory.Application;

namespace DesignPatterns.AbstractFactory.Domain
{
    public class Customer
    {
        #region Core

        public Customer(Source source)
        {
            Source = source;
        }

        #endregion

        #region Public Interface

        public Source Source { get; }

        #endregion
    }
}
