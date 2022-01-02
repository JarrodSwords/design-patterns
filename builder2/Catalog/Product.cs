using System;
using DesignPatterns.Builder2.Shared;

namespace DesignPatterns.Builder2.Catalog
{
    public partial class Product : Aggregate
    {
        public static readonly Product DietPepsi = new(Vendor.PepsiCo, "Diet Pepsi", "diet");
        public static readonly Product Pepsi = new(Vendor.PepsiCo, "Pepsi", "reg");

        #region Creation

        private Product(
            Vendor vendor,
            string name,
            string skuToken
        )
        {
            CompanyId = vendor.Id;
            Name = name;
            Sku = GenerateSku(vendor.SkuToken, skuToken);
        }

        #endregion

        #region Public Interface

        public Guid CompanyId { get; }
        public string Name { get; }
        public string Sku { get; }

        #endregion

        #region Static Interface

        private static string GenerateSku(string vendorSkuToken, string skuToken) => $"{vendorSkuToken}-{skuToken}";

        #endregion
    }
}
