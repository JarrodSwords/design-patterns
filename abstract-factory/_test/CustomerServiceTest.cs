using DesignPatterns.AbstractFactory.Application;
using DesignPatterns.AbstractFactory.Domain;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.AbstractFactory
{
    public class CustomerServiceTest
    {
        #region Test Methods

        [Theory]
        [InlineData(Source.Database)]
        [InlineData(Source.Cache)]
        public void WhenFetchingContracts_WithSource_ReturnsContractsFromSource(Source source)
        {
            var service = new CustomerService(source);
            var contracts = service.FetchContracts();

            contracts.Should().OnlyContain(x => x.Source == source);
        }

        [Theory]
        [InlineData(Source.Database)]
        [InlineData(Source.Cache)]
        public void WhenFetchingCustomers_WithSource_ReturnsCustomersFromSource(Source source)
        {
            var service = new CustomerService(source);
            var customers = service.FetchCustomers();

            customers.Should().OnlyContain(x => x.Source == source);
        }

        #endregion
    }
}
