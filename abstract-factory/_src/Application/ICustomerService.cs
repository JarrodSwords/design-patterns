using System.Collections.Generic;
using DesignPatterns.AbstractFactory.Domain;

namespace DesignPatterns.AbstractFactory.Application
{
    public interface ICustomerService
    {
        ICollection<Contract> FetchContracts();
        ICollection<Customer> FetchCustomers();
    }
}
