using Jgs.Errors.Results;

namespace DesignPatterns.Builder3.Shop.Infrastructure;

public partial class OrderRepository : IOrderRepository
{
    private ISequentialOrderBuilder _builder;

    public IOrderRepository Fetch()
    {
        var orders = new List<Order>();
        var director = new Director();

        foreach (var o in orders)
            director.Configure(_builder, o);

        return this;
    }

    public IOrderRepository Configure(ISequentialOrderBuilder builder)
    {
        _builder = builder;
        return this;
    }

    public Result Fetch(params Guid[] ids) => throw new NotImplementedException();

    public Result Fetch(Guid customerId) => throw new NotImplementedException();

    public Result Fetch(Guid customerId, DateTime orderPlaced) => throw new NotImplementedException();

    public Result Find(Guid id)
    {
        var order = new List<Order>().SingleOrDefault(x => x.Id == id);

        if (order is null)
            return OrderNotFound();

        return new Director().Configure(_builder, order);
    }
}
