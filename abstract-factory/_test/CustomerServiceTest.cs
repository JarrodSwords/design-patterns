using CreationalPatterns.AbstractFactory.Application;
using CreationalPatterns.AbstractFactory.Domain;
using FluentAssertions;
using Xunit;

namespace CreationalPatterns.AbstractFactory
{
    public class CustomerServiceTest
    {
        #region Requirements

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
