namespace DesignPatterns.Composite.Domain;

public interface ISalePriceCalculator
{
    decimal CalculateSalePrice(Product product, Discount? discount = null);
}
