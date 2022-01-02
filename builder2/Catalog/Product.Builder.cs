using DesignPatterns.Builder2.Shared;

namespace DesignPatterns.Builder2.Catalog
{
    public partial class Product : Aggregate
    {
        public abstract class Builder : IProductBuilder
        {
            #region Public Interface

            public Product Build() => new(Vendor, Name, SkuToken);

            #endregion

            #region Protected Interface

            protected string Name { get; set; }
            protected string SkuToken { get; set; }
            protected Vendor Vendor { get; set; }

            #endregion

            #region IProductBuilder Implementation

            public abstract IProductBuilder GetVendor();

            #endregion
        }
    }
}
