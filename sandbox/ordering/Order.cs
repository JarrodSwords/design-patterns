namespace DesignPatterns.Sandbox.ordering;

public partial class Order
{
    protected State _state = new Canceled(this);

    public void Add(LineItem li) => _state.AddLineItem(li);
    public void Cancel() => _state.Cancel();
    public void Charge(PaymentDetails paymentDetails) => _state.Charge(paymentDetails);
    public void RemoveLineItem(Guid lineItemdId) => _state.RemoveLineItem(lineItemdId);
}
