namespace DesignPatterns.Composite.SalePriceCalculator.Spec;

public class WhenCalculatingSalePrice
{
    #region Implementation

    public static IEnumerable<object[]> GetServices()
    {
        return new List<object[]> { new object[] { new Domain.Primitive.SalePriceCalculator() } };
    }

    #endregion

    #region Requirements

    [Theory]
    [MemberData(nameof(GetServices))]
    public void WithoutDiscounts_ThenPriceIsListPrice(ISalePriceCalculator calculator)
    {
        var product = new Product("bread", 2.99m);
        var salePrice = calculator.CalculateSalePrice(product);

        salePrice.Should().Be(product.ListPrice);
    }

    #endregion
}
