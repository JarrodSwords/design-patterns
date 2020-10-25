using System;
using System.Collections.Generic;
using DesignPatterns.AbstractFactory.Domain;
using DesignPatterns.AbstractFactory.Persistence.Database;

namespace DesignPatterns.AbstractFactory.Application
{
    /// <summary>
    ///     Client
    /// </summary>
    public class CustomerService
    {
        #region Core

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(Source source)
        {
            var factory = source switch
            {
                Source.Database => (IRepositoryFactory) new RepositoryFactory(),
                Source.Cache => new Persistence.Cache.RepositoryFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(source), source, null)
            };

            _customerRepository = factory.CreateCustomerRepository();
        }

        #endregion

        #region Public Interface

        public ICollection<Customer> FetchCustomers()
        {
            return _customerRepository.Fetch();
        }

        #endregion
    }
}
