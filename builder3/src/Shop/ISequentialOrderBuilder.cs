namespace DesignPatterns.Builder3.Shop;

public interface ISequentialOrderBuilder
{
    ISequentialOrderBuilder Add(LineItemDto lineItem);
    ISequentialOrderBuilder Set(OrderInfo orderInfo);
}

public record OrderInfo(Guid Id, Guid CustomerId);

public record LineItemDto(Guid Id, decimal Price, string Sku);
