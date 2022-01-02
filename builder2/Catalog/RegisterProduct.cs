using System;
using DesignPatterns.Builder2.Shared;
using DesignPatterns.Builder2.Write;

namespace DesignPatterns.Builder2.Catalog
{
    public record RegisterProduct(
        Guid VendorId,
        string Name,
        string SkuToken
    ) : ICommand
    {
        public class Builder : IProductBuilder
        {
            private readonly Product.Builder _builder;
            private readonly UnitOfWork _uow;
            private string _skuToken;
            private Guid _vendorId;

            #region Creation

            public Builder(UnitOfWork uow)
            {
                _builder = new Product.Builder();
                _uow = uow;
            }

            #endregion

            #region Public Interface

            public Product Build() => _builder.Build();

            public Builder From(RegisterProduct command)
            {
                var (vendorId, name, skuToken) = command;

                _builder
                    .With(vendorId)
                    .WithName(name);

                _skuToken = skuToken;
                _vendorId = vendorId;

                return this;
            }

            #endregion

            #region IProductBuilder Implementation

            public void GenerateSku()
            {
                var vendor = _uow.Vendors.Find(_vendorId);
                var sku = Product.GenerateSku(vendor.SkuToken, _skuToken);
                _builder.WithSku(sku);
            }

            #endregion
        }
    }
}
