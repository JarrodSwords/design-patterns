using System.Collections.Generic;
using CreationalPatterns.AbstractFactory.Domain;

namespace CreationalPatterns.AbstractFactory.Persistence.Cache
{
    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        public ICollection<Customer> Fetch() => new List<Customer> { new Customer(Source.Cache) };
    }
}
