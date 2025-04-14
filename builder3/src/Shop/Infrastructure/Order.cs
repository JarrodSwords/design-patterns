namespace DesignPatterns.Builder3.Shop.Infrastructure;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public IEnumerable<LineItem> LineItems { get; set; }
}
