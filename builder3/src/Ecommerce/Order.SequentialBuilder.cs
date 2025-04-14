namespace DesignPatterns.Builder3.Ecommerce;

public partial class Order
{
    private Order()
    {
    }

    public class SequentialBuilder : ISequentialOrderBuilder
    {
        private readonly Order _order = new();
        public Order GetOrder() => _order;

        public ISequentialOrderBuilder Add(LineItemDto orderInfo) => throw new NotImplementedException();

        public ISequentialOrderBuilder Set(OrderInfo orderInfo) => throw new NotImplementedException();
    }
}
