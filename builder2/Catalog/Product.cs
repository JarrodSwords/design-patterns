using System;
using DesignPatterns.Builder2.Shared;

namespace DesignPatterns.Builder2.Catalog
{
    public partial class Product : Aggregate
    {
        #region Creation

        private Product(Guid vendorId, string name, string sku)
        {
            CompanyId = vendorId;
            Name = name;
            Sku = sku;
        }

        #endregion

        #region Public Interface

        public Guid CompanyId { get; }
        public string Name { get; }
        public string Sku { get; }

        #endregion

        #region Static Interface

        public static string GenerateSku(string vendorSkuToken, string skuToken) => $"{vendorSkuToken}-{skuToken}";

        #endregion
    }
}
