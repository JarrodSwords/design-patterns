namespace DesignPatterns.Builder2.Services
{
    public interface IOrderBuilder
    {
        IOrderBuilder SetCustomerInfo();
        IOrderBuilder SetLineItems();
        IOrderBuilder SetPaymentInfo();
    }
}
