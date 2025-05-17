namespace DesignPatterns.Sandbox.ordering;

public partial class Order
{
    public abstract class State
    {
        protected Order _order;

        protected State(Order order)
        {
            _order = order;
        }

        public abstract void AddLineItem(LineItem li);
        public abstract void Cancel();
        public abstract void Charge(PaymentDetails paymentDetails);
        public abstract void RemoveLineItem(Guid lineItemId);

        protected void SetState(State state) => _order._state = state;
    }
}
