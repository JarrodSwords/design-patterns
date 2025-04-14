using Jgs.Errors;

namespace DesignPatterns.Builder3.Infrastructure;

public partial class OrderRepository : IOrderRepository
{
    private Error OrderNotFound() => new("order.not.found");
}
