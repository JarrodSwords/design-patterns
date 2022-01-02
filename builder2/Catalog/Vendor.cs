using DesignPatterns.Builder2.Shared;

namespace DesignPatterns.Builder2.Catalog
{
    public class Vendor : Aggregate
    {
        public static readonly Vendor PepsiCo = new("PepsiCo", "pep");

        #region Creation

        public Vendor(string name, string skuToken)
        {
            Name = name;
            SkuToken = skuToken;
        }

        #endregion

        #region Public Interface

        public string Name { get; }
        public string SkuToken { get; }

        #endregion
    }
}
