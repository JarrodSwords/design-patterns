using System.Collections;

namespace DesignPatterns.Memento;

public partial class Order : IEnumerable<LineItem>
{
    private readonly Dictionary<uint, LineItem> _lineItems = new();

    public Guid Id { get; } = Guid.NewGuid();
    public DateTime LastUpdated { get; private set; }

    public Order Add(LineItem lineItem)
    {
        _lineItems.Add(lineItem.Id, lineItem);
        SetLastUpdated();

        return this;
    }

    public Order Remove(LineItem lineItem)
    {
        _lineItems.Remove(lineItem.Id);
        SetLastUpdated();

        return this;
    }

    private void SetLastUpdated()
    {
        LastUpdated = DateTime.Now;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator<LineItem> GetEnumerator() => _lineItems.Values.GetEnumerator();
}
