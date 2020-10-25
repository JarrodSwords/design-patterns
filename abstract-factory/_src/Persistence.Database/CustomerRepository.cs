using System.Collections.Generic;
using DesignPatterns.AbstractFactory.Application;
using DesignPatterns.AbstractFactory.Domain;

namespace DesignPatterns.AbstractFactory.Persistence.Database
{
    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        #region ICustomerRepository

        public ICollection<Customer> Fetch()
        {
            return new List<Customer> {new Customer(Source.Database)};
        }

        #endregion
    }
}
