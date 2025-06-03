namespace BehavioralPatterns.Memento;

public partial class Order
{
    public Memento CreateMemento() =>
        new(
            Id,
            LastUpdated,
            _lineItems.ToDictionary(x => x.Key, x => x.Value)
        );

    public Order Restore(Memento memento)
    {
        var (id, lastUpdated, lineItems) = memento;

        _lineItems.Clear();

        foreach (var (key, li) in lineItems)
            _lineItems.Add(key, li);

        LastUpdated = lastUpdated;
        return this;
    }

    public record Memento(
        Guid Id,
        DateTime LastUpdated,
        IReadOnlyDictionary<uint, LineItem> LineItems
    );
}
