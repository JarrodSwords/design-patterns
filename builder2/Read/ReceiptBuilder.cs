using System;
using System.Collections.Generic;
using DesignPatterns.Builder2.Services;

namespace DesignPatterns.Builder2.Read
{
    public class ReceiptBuilder : IOrderBuilder
    {
        private string _customerId;
        private List<ReceiptDto.LineItemDto> _lineItems;
        private decimal _total;

        #region Public Interface

        public ReceiptDto Build() => new(_customerId, _lineItems, _total);

        #endregion

        #region IOrderBuilder Implementation

        public IOrderBuilder SetCustomerInfo() => _customerId = ;
        public IOrderBuilder SetLineItems() => throw new NotImplementedException();
        public IOrderBuilder SetPaymentInfo() => throw new NotImplementedException();

        #endregion
    }
}
