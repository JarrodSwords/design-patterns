using System.Collections.Generic;
using CreationalPatterns.AbstractFactory.Domain;

namespace CreationalPatterns.AbstractFactory.Application
{
    public interface ICustomerService
    {
        ICollection<Contract> FetchContracts();
        ICollection<Customer> FetchCustomers();
    }
}
