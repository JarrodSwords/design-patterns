using System;
using CreationalPatterns.Builder2.Catalog;

namespace CreationalPatterns.Builder2.Write
{
    public partial class Product : Entity
    {
        public static readonly Product DietPepsi = new("Diet Pepsi", "pep-diet", Vendor.PepsiCo.Id);
        public static readonly Product Pepsi = new("Pepsi", "pep-cola", Vendor.PepsiCo.Id);

        public Product()
        {
        }

        private Product(string name, string sku, Guid vendorId)
        {
            Name = name;
            Sku = sku;
            VendorId = vendorId;
        }

        public Guid VendorId { get; set; }

        public string Name { get; set; }
        public string Sku { get; set; }
    }
}
