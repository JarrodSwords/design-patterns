using System;

namespace DesignPatterns.Builder2.Catalog
{
    public partial class Product
    {
        public abstract class Builder : IProductBuilder
        {
            #region Public Interface

            public Product Build() => new(VendorId, Name, Sku);

            #endregion

            #region Protected Interface

            protected string Name { get; set; }
            protected string Sku { get; set; }
            protected Guid VendorId { get; set; }

            #endregion

            #region IProductBuilder Implementation

            public virtual void GenerateSku()
            {
            }

            #endregion
        }
    }
}
