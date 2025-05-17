namespace DesignPatterns.Sandbox.ordering;

public class Creating : Order.State
{
    public Creating(Order order) : base(order)
    {
    }

    public override void AddLineItem(LineItem li)
    {
        // do adding
    }

    public override void Cancel()
    {
        SetState(new Canceled(_));
    }

    public override void Charge(PaymentDetails paymentDetails)
    {
        throw new NotImplementedException();
    }

    public override void RemoveLineItem(Guid lineItemId)
    {
        // do removing
    }
}
