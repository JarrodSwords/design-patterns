using CreationalPatterns.Builder2.Shared;

namespace CreationalPatterns.Builder2.Catalog
{
    public class Vendor : Aggregate
    {
        public static readonly Vendor PepsiCo = new("PepsiCo", "pep");

        public Vendor(string name, string skuToken)
        {
            Name = name;
            SkuToken = skuToken;
        }

        public string Name { get; }
        public string SkuToken { get; }
    }
}
