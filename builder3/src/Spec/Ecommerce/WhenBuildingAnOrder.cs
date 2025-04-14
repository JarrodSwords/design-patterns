using DesignPatterns.Builder3.Infrastructure;
using FluentAssertions;
using FluentAssertions.Execution;
using Order = DesignPatterns.Builder3.Ecommerce.Order;

namespace DesignPatterns.Builder3.Spec.Ecommerce;

public class WhenBuildingAnOrder
{
    #region Requirements

    [Fact]
    public void By_Then()
    {
        var builder = new Order.SequentialBuilder();

        new OrderRepository()
            .Configure(builder)
            .Find(Guid.NewGuid());

        var order = builder.GetOrder();

        using var scope = new AssertionScope();

        order.Should().NotBeNull();
        order.LineItems.Should().HaveCount(3);
    }

    #endregion
}
