using System;

namespace DesignPatterns.Builder2.Read
{
    public record LineItem(
        Guid Id,
        Guid ProductId,
        decimal Price,
        ushort Quantity
    );
}
