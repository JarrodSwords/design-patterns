using DesignPatterns.Builder2.Services;

namespace DesignPatterns.Builder2.Read
{
    public class OrderDirector
    {
        private IOrderBuilder _builder;

        #region Public Interface

        public OrderDirector BuildInvoice()
        {
            _builder
                .SetCustomerInfo()
                .SetLineItems()
                .SetPaymentInfo();

            return this;
        }

        public OrderDirector BuildReceipt()
        {
            _builder
                .SetCustomerInfo()
                .SetLineItems()
                .SetPaymentInfo();

            return this;
        }

        public OrderDirector BuildShippingRequest()
        {
            _builder
                .SetCustomerInfo()
                .SetLineItems();

            return this;
        }

        public OrderDirector With(IOrderBuilder builder)
        {
            _builder = builder;
            return this;
        }

        #endregion
    }
}
