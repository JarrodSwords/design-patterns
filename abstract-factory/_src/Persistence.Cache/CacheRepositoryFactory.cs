using DesignPatterns.AbstractFactory.Domain;

namespace DesignPatterns.AbstractFactory.Persistence.Cache
{
    /// <summary>
    ///     Concrete Factory
    /// </summary>
    public class CacheRepositoryFactory : IRepositoryFactory
    {
        #region IRepositoryFactory

        public ICustomerRepository CreateCustomerRepository()
        {
            return new CachedCustomerRepository();
        }

        #endregion
    }
}
