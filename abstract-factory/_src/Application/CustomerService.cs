using System;
using System.Collections.Generic;
using CreationalPatterns.AbstractFactory.Domain;
using CreationalPatterns.AbstractFactory.Persistence.Database;

namespace CreationalPatterns.AbstractFactory.Application
{
    /// <summary>
    ///     Client
    /// </summary>
    public class CustomerService : ICustomerService
    {
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

        public ICollection<Contract> FetchContracts() => _contractRepository.Fetch();

        public ICollection<Customer> FetchCustomers() => _customerRepository.Fetch();
    }
}
