using System;
using CreationalPatterns.Builder2.Shared;

namespace CreationalPatterns.Builder2.Catalog
{
    public partial class Product : Aggregate
    {
        private Product(Guid vendorId, string name, string sku)
        {
            CompanyId = vendorId;
            Name = name;
            Sku = sku;
        }

        public Guid CompanyId { get; }
        public string Name { get; }
        public string Sku { get; }

        public static string GenerateSku(string vendorSkuToken, string skuToken) => $"{vendorSkuToken}-{skuToken}";
    }
}
