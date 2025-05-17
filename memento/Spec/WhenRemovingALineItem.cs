using FluentAssertions;

namespace DesignPatterns.Memento.Spec;

public class WhenRemovingALineItem
{
    #region Setup

    private readonly LineItem _lineItem = new(1, "ABC123", 1);
    private readonly Order _order = new();
    private DateTime _added;
    private readonly DateTime _removed;

    public WhenRemovingALineItem()
    {
        _order.Add(_lineItem);
        _added = _order.LastUpdated;

        _order.Remove(_lineItem);
        _removed = _order.LastUpdated;
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenLastUpdatedIsSet()
    {
        _order.LastUpdated.Should().Be(_removed);
    }

    [Fact]
    public void ThenOrderDoesNotContainLineItem()
    {
        _order.Should().NotContain(_lineItem);
    }

    #endregion
}
