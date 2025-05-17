namespace DesignPatterns.Sandbox.ordering;

public class Shipped : Order.State
{
    public Shipped(Order order) : base(order)
    {
    }

    public override void AddLineItem(LineItem li)
    {
        throw new NotImplementedException();
    }

    public override void Cancel()
    {
        throw new NotImplementedException();
    }

    public override void Charge(PaymentDetails paymentDetails)
    {
        throw new NotImplementedException();
    }

    public override void RemoveLineItem(Guid lineItemId)
    {
        throw new NotImplementedException();
    }
}
