using Jgs.Errors;

namespace DesignPatterns.Builder3.Shop.Infrastructure;

public partial class OrderRepository : IOrderRepository
{
    private Error OrderNotFound() => new("order.not.found");
}
