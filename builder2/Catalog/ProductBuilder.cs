using System;
using DesignPatterns.Builder2.Write;

namespace DesignPatterns.Builder2.Catalog
{
    public class ProductBuilder : Product.Builder
    {
        private readonly UnitOfWork _uow;
        private Guid _vendorId;

        #region Creation

        public ProductBuilder(UnitOfWork uow)
        {
            _uow = uow;
        }

        #endregion

        #region Public Interface

        public ProductBuilder From(RegisterProduct command)
        {
            var (vendorId, name, skuToken) = command;

            _vendorId = vendorId;
            Name = name;
            SkuToken = skuToken;

            return this;
        }

        public override IProductBuilder GetVendor()
        {
            Vendor = _uow.Vendors.Find(_vendorId);
            return this;
        }

        #endregion
    }
}
