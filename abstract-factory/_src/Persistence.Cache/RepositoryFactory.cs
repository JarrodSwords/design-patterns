using DesignPatterns.AbstractFactory.Domain;

namespace DesignPatterns.AbstractFactory.Persistence.Cache
{
    /// <summary>
    ///     Concrete Factory
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        #region IRepositoryFactory

        public IContractRepository CreateContractRepository()
        {
            return new ContractRepository();
        }

        public ICustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository();
        }

        #endregion
    }
}
