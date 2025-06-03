using StructuralPatterns.Composite.Domain;

namespace StructuralPatterns.Composite.SalePriceCalculator.Spec;

public class WhenCalculatingSalePrice
{
    #region Setup

    private readonly Product _product = new("bread", 2.99m);

    #endregion

    #region Implementation

    public static IEnumerable<object[]> GetServices()
    {
        return new List<object[]> { new object[] { new Domain.Primitive.SalePriceCalculator() } };
    }

    #endregion

    #region Requirements

    [Theory]
    [MemberData(nameof(GetServices))]
    public void WithFlatReduction_ThenSalePriceIsListPriceMinusReduction(ISalePriceCalculator calculator)
    {
        var salePrice = calculator.CalculateSalePrice(_product, new FlatReduction(1m));

        salePrice.Should().Be(1.99m);
    }

    [Theory]
    [MemberData(nameof(GetServices))]
    public void WithoutDiscounts_ThenSalePriceIsListPrice(ISalePriceCalculator calculator)
    {
        var salePrice = calculator.CalculateSalePrice(_product);

        salePrice.Should().Be(_product.ListPrice);
    }

    [Theory]
    [MemberData(nameof(GetServices))]
    public void WithPercentageDiscount_ThenSalePriceIsListPriceMinusPercentageTimesListPrice(
        ISalePriceCalculator calculator
    )
    {
        var salePrice = calculator.CalculateSalePrice(_product, new PercentageDiscount(10));

        salePrice.Should().Be(2.69m);
    }

    [Theory]
    [MemberData(nameof(GetServices))]
    public void WithPriceMatch_ThenSalePriceIsMatchPrice(ISalePriceCalculator calculator)
    {
        var salePrice = calculator.CalculateSalePrice(_product, new PriceMatch(2.49m));

        salePrice.Should().Be(2.49m);
    }

    #endregion
}
