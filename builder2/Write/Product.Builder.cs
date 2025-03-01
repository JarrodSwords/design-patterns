namespace DesignPatterns.Builder2.Write
{
    public partial class Product
    {
        public class Builder
        {
            private readonly Catalog.Product.Builder _builder = new();

            #region Public Interface

            public Catalog.Product Build() => _builder.Build();

            public Builder With(Product product)
            {
                _builder
                    .With(product.VendorId)
                    .WithName(product.Name)
                    .WithSku(product.Sku);

                return this;
            }

            #endregion
        }
    }
}
