namespace DesignPatterns.Composite.Domain.Primitive;

public class SalePriceCalculator : ISalePriceCalculator
{
    public decimal CalculateSalePrice(Product product) => product.ListPrice;
}
