﻿namespace StructuralPatterns.Composite.Domain;

public abstract class Discount
{
    public abstract decimal Apply(Product product);
}

public class FlatReduction : Discount
{
    public FlatReduction(decimal reduction)
    {
        Reduction = reduction;
    }

    public decimal Reduction { get; }
    public override decimal Apply(Product product) => product.ListPrice - Math.Abs(Reduction);
}

public class PriceMatch : Discount
{
    public PriceMatch(decimal price)
    {
        Price = price;
    }

    public decimal Price { get; }

    public override decimal Apply(Product product) => Price;
}

public class PercentageDiscount : Discount
{
    public PercentageDiscount(int percentage)
    {
        Percentage = percentage;
    }

    public int Percentage { get; }

    public override decimal Apply(Product product) =>
        product.ListPrice - Math.Round((decimal) Percentage / 100 * product.ListPrice, 2);
}
