using CreationalPatterns.AbstractFactory.Domain;

namespace CreationalPatterns.AbstractFactory.Persistence.Cache
{
    /// <summary>
    ///     Concrete Factory
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        public IContractRepository CreateContractRepository() => new ContractRepository();

        public ICustomerRepository CreateCustomerRepository() => new CustomerRepository();
    }
}
