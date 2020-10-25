using DesignPatterns.AbstractFactory.Domain;

namespace DesignPatterns.AbstractFactory.Persistence
{
    /// <summary>
    ///     Concrete Factory
    /// </summary>
    public class DatabaseRepositoryFactory : IRepositoryFactory
    {
        #region IRepositoryFactory

        public ICustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository();
        }

        #endregion
    }
}
