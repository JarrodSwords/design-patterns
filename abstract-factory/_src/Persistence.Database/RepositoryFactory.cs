using DesignPatterns.AbstractFactory.Domain;

namespace DesignPatterns.AbstractFactory.Persistence.Database
{
    /// <summary>
    ///     Concrete Factory
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        #region IRepositoryFactory

        public ICustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository();
        }

        #endregion
    }
}
