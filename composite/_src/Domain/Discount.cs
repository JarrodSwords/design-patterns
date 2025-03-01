namespace DesignPatterns.Composite.Domain;

public abstract class Discount
{
    public abstract decimal Apply(Product product);
}
