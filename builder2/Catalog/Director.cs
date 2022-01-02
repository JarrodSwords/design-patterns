namespace DesignPatterns.Builder2.Catalog
{
    public class Director
    {
        private IProductBuilder _builder;

        #region Public Interface

        public Director CreateNewProduct()
        {
            _builder.GetVendor();
            return this;
        }

        public Director With(IProductBuilder builder)
        {
            _builder = builder;
            return this;
        }

        #endregion
    }
}
