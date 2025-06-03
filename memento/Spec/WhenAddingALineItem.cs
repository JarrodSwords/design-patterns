using FluentAssertions;

namespace BehavioralPatterns.Memento.Spec;

public class WhenAddingALineItem
{
    #region Setup

    private readonly LineItem _lineItem = new(1, "ABC123", 1);
    private readonly Order _order = new();

    public WhenAddingALineItem()
    {
        _order.Add(_lineItem);
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenLastUpdatedIsSet()
    {
        _order.LastUpdated.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(20));
    }

    [Fact]
    public void ThenOrderContainsLineItem()
    {
        _order.Should().Contain(_lineItem);
    }

    #endregion
}
