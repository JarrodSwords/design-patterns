namespace DesignPatterns.Builder3.Infrastructure;

public class LineItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
}
