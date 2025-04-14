namespace DesignPatterns.Builder3.Ecommerce;

public partial class Order
{
    private readonly List<LineItem> _lineItems = [];

    public Guid Id { get; }
    public Guid CustomerId { get; }
    public IReadOnlyList<LineItem> LineItems { get; }
}
