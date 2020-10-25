namespace DesignPatterns.AbstractFactory.Domain
{
    /// <summary>
    ///     Abstract Factory
    /// </summary>
    public interface IRepositoryFactory
    {
        ICustomerRepository CreateCustomerRepository();
    }
}
