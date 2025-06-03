using FluentAssertions;

namespace BehavioralPatterns.Memento.Spec;

public class WhenUndoing
{
    #region Setup

    private readonly DateTime _added;
    private readonly LineItem _lineItem = new(1, "ABC123", 1);
    private readonly Order _order = new();

    public WhenUndoing()
    {
        _order.Add(_lineItem);
        _added = _order.LastUpdated;

        var memento = _order.CreateMemento();

        _order
            .Remove(_lineItem)
            .Restore(memento);
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenLastUpdatedIsSet()
    {
        _order.LastUpdated.Should().Be(_added);
    }

    [Fact]
    public void ThenOrderContainsRemovedLineItem()
    {
        _order.Should().Contain(_lineItem);
    }

    #endregion
}
