using System.Collections.Generic;
using DesignPatterns.AbstractFactory.Application;
using DesignPatterns.AbstractFactory.Domain;

namespace DesignPatterns.AbstractFactory.Persistence.Cache
{
    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class CachedCustomerRepository : ICustomerRepository
    {
        #region ICustomerRepository

        public ICollection<Customer> Fetch()
        {
            return new List<Customer> {new Customer(Source.Cache)};
        }

        #endregion
    }
}
