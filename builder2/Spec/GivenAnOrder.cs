using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Builder2.Read;
using DesignPatterns.Builder2.Services;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.Builder2.Spec
{
    public class GivenAnOrder
    {
        #region Core

        private readonly OrderDirector _director;
        private readonly Order _order;

        public GivenAnOrder()
        {
            _director = new OrderDirector();

            _order = new Order(
                Guid.NewGuid(),
                Customer.Jon,
                new List<LineItem>
                {
                    new(Guid.NewGuid(), Product.Pants.Id, Product.Pants.Price, 1),
                    new(Guid.NewGuid(), Product.Shirt.Id, Product.Shirt.Price, 2)
                }
            );
        }

        #endregion

        #region Test Methods

        //[Fact]
        //public void WhenCreatingAnInvoice()
        //{
        //    var invoiceBuilder = new ReceiptDto.Builder();

        //    _director.With(invoiceBuilder).BuildInvoice();

        //    var invoice = invoiceBuilder.Build();

        //    invoice.Should().NotBeNull();
        //}

        [Fact]
        public void WhenCreatingAReceipt()
        {
            var receiptBuilder = new ReceiptBuilder();
            _director.With(receiptBuilder).BuildReceipt();

            var receipt = receiptBuilder.Build();

            receipt.Should().NotBeNull();
            receipt.CustomerId.Should().Be(Customer.Jon.RecordName);
            receipt.LineItems.Should().HaveCount(3);
            receipt.Total.Should().Be(
                receipt.LineItems.Aggregate(0m, (current, li) => current + li.Price)
            );
        }

        #endregion

        //[Fact]
        //public void WhenCreatingAShippingRequest()
        //{
        //    var shippingRequestBuilder = new ReceiptDto.Builder();

        //    _director.With(shippingRequestBuilder).BuildShippingRequest();

        //    var shippingRequest = shippingRequestBuilder.Build();

        //    shippingRequest.Should().NotBeNull();
        //}
    }
}
