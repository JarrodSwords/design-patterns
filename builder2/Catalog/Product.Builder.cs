using System;

namespace DesignPatterns.Builder2.Catalog
{
    public partial class Product
    {
        public class Builder
        {
            private string _name;
            private string _sku;
            private Guid _vendorId;

            #region Public Interface

            public Product Build() => new(_vendorId, _name, _sku);

            public Builder With(Guid vendorId)
            {
                _vendorId = vendorId;
                return this;
            }

            public Builder WithName(string name)
            {
                _name = name;
                return this;
            }

            public Builder WithSku(string sku)
            {
                _sku = sku;
                return this;
            }

            #endregion
        }
    }
}
