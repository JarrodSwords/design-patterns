namespace DesignPatterns.Composite.Domain;

public class Product
{
    public Product(string name, decimal listPrice)
    {
        ListPrice = listPrice;
        Name = name;
    }

    public decimal ListPrice { get; }
    public string Name { get; }
}
