using CreationalPatterns.Builder2.Catalog;
using FluentAssertions;
using Xunit;

namespace CreationalPatterns.Builder2
{
    public class GivenAnExistingProduct
    {
        #region Setup

        private readonly Product _product;

        public GivenAnExistingProduct()
        {
            _product = new Write.Product.Builder()
                .With(Write.Product.Pepsi)
                .Build();
        }

        #endregion

        #region Requirements

        [Fact]
        public void WhenCreatingAProduct_ThenCompanyIdIsSet()
        {
            _product.CompanyId.Should().Be(Write.Product.Pepsi.VendorId);
        }

        [Fact]
        public void WhenCreatingAProduct_ThenNameIsSet()
        {
            _product.Name.Should().Be(Write.Product.Pepsi.Name);
        }

        [Fact]
        public void WhenCreatingAProduct_ThenSkuIsSet()
        {
            _product.Sku.Should().Be(Write.Product.Pepsi.Sku);
        }

        #endregion
    }
}
