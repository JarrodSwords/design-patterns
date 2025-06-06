namespace CreationalPatterns.AbstractFactory.Domain
{
    /// <summary>
    ///     Abstract Factory
    /// </summary>
    public interface IRepositoryFactory
    {
        IContractRepository CreateContractRepository();
        ICustomerRepository CreateCustomerRepository();
    }
}
