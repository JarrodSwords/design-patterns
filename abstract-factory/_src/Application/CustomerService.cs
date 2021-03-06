using System;
using System.Collections.Generic;
using DesignPatterns.AbstractFactory.Domain;
using DesignPatterns.AbstractFactory.Persistence.Database;

namespace DesignPatterns.AbstractFactory.Application
{
    /// <summary>
    ///     Client
    /// </summary>
    public class CustomerService : ICustomerService
    {
        #region Core

        private readonly IContractRepository _contractRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(Source source)
        {
            var factory = source switch
            {
                Source.Database => (IRepositoryFactory) new RepositoryFactory(),
                Source.Cache => new Persistence.Cache.RepositoryFactory(),
                _ => throw new ArgumentOutOfRangeException(nameof(source), source, null)
            };

            _contractRepository = factory.CreateContractRepository();
            _customerRepository = factory.CreateCustomerRepository();
        }

        #endregion

        #region ICustomerService

        public ICollection<Contract> FetchContracts()
        {
            return _contractRepository.Fetch();
        }

        public ICollection<Customer> FetchCustomers()
        {
            return _customerRepository.Fetch();
        }

        #endregion
    }
}
