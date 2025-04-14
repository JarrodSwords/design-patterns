using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace DesignPatterns.Builder3.Infrastructure;

public class Director
{
    public Result Configure(ISequentialOrderBuilder builder, Order order)
    {
        builder.Set(new(order.Id, order.CustomerId));

        foreach (var li in order.LineItems)
            builder.Add(new LineItemDto(li.Id, li.Price, li.Sku));

        return Success();
    }
}
