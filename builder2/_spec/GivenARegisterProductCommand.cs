using System.Collections.Generic;
using DesignPatterns.Builder2.Catalog;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.Builder2
{
    public class GivenARegisterProductCommand
    {
        #region Core

        private readonly RegisterProduct.Builder _builder;

        public GivenARegisterProductCommand()
        {
            _builder = new RegisterProduct.Builder(new());
        }

        #endregion

        #region Public Interface

        public static IEnumerable<object[]> CandidateProducts =>
            new List<object[]>
            {
                new object[] { "Crystal Pepsi", "cry" },
                new object[] { "Wild Cherry Pepsi", "cherry" }
            };

        #endregion

        #region Private Interface

        private void ConfigureBuilder(string name, string skuToken)
        {
            var command = new RegisterProduct(Vendor.PepsiCo.Id, name, skuToken);

            _builder.From(command);
        }

        #endregion

        #region Test Methods

        [Theory]
        [MemberData(nameof(CandidateProducts))]
        public void WhenCreatingAProduct_ThenCompanyIdIsSet(string name, string skuToken)
        {
            ConfigureBuilder(name, skuToken);

            var product = _builder.Build();

            product.CompanyId.Should().Be(Vendor.PepsiCo.Id);
        }

        [Theory]
        [MemberData(nameof(CandidateProducts))]
        public void WhenCreatingAProduct_ThenNameIsSet(string name, string skuToken)
        {
            ConfigureBuilder(name, skuToken);

            var product = _builder.Build();

            product.Name.Should().Be(name);
        }

        [Theory]
        [MemberData(nameof(CandidateProducts))]
        public void WhenCreatingAProduct_ThenSkuIsGenerated(string name, string skuToken)
        {
            ConfigureBuilder(name, skuToken);

            var product = _builder.Build();

            product.Sku.Should().Be($"{Vendor.PepsiCo.SkuToken}-{skuToken}");
        }

        #endregion
    }
}
