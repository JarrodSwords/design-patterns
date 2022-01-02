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
        public class Builder : Product.Builder
        {
            private readonly UnitOfWork _uow;
            private string _skuToken;

            #region Creation

            public Builder(UnitOfWork uow)
            {
                _uow = uow;
            }

            #endregion

            #region Public Interface

            public Builder From(RegisterProduct command)
            {
                var (vendorId, name, skuToken) = command;

                Name = name;
                VendorId = vendorId;
                _skuToken = skuToken;

                return this;
            }

            public override void GenerateSku()
            {
                var vendor = _uow.Vendors.Find(VendorId);
                Sku = Product.GenerateSku(vendor.SkuToken, _skuToken);
            }

            #endregion
        }
    }
}
