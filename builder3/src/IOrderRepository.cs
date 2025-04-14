using Jgs.Errors.Results;

namespace DesignPatterns.Builder3;

public interface IOrderRepository
{
    IOrderRepository Configure(ISequentialOrderBuilder builder);
    Result Fetch(params Guid[] ids);
    Result Fetch(Guid customerId);
    Result Fetch(Guid customerId, DateTime orderPlaced);
    Result Find(Guid id);
}
