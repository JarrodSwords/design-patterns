using FluentAssertions;
using FluentAssertions.Execution;

namespace DesignPatterns.Memento.Spec;

public class WhenRemovingALineItem
{
    #region Setup

    private readonly DateTime _added;
    private readonly LineItem _lineItem = new(1, "ABC123", 1);
    private readonly Order _order = new();
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
        using var scope = new AssertionScope();

        _order.LastUpdated.Should().Be(_removed);
        _order.LastUpdated.Should().BeAfter(_added);
    }

    [Fact]
    public void ThenOrderDoesNotContainLineItem()
    {
        _order.Should().NotContain(_lineItem);
    }

    #endregion
}
