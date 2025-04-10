namespace DesignPatterns.Composite.Domain.Primitive;

public class SalePriceCalculator : ISalePriceCalculator
{
    public decimal CalculateSalePrice(Product product, Discount? discount = null) =>
        discount?.Apply(product) ?? product.ListPrice;
}
