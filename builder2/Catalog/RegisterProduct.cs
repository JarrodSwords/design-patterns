using System;
using DesignPatterns.Builder2.Shared;
using DesignPatterns.Builder2.Write;

namespace DesignPatterns.Builder2.Catalog
{
    public record RegisterProduct(
        Guid VendorId,
        string Name,
        string SkuToken
    ) : ICommand
    {
        public class Builder
        {
            private readonly Product.Builder _builder;
            private readonly UnitOfWork _uow;
            private RegisterProduct _command;

            #region Creation

            public Builder(UnitOfWork uow)
            {
                _builder = new Product.Builder();
                _uow = uow;
            }

            #endregion

            #region Public Interface

            public Product Build() =>
                _builder
                    .With(_command.VendorId)
                    .WithName(_command.Name)
                    .WithSku(GenerateSku())
                    .Build();

            public Builder From(RegisterProduct command)
            {
                _command = command;
                return this;
            }

            public string GenerateSku()
            {
                var vendor = _uow.Vendors.Find(_command.VendorId);
                return Product.GenerateSku(vendor.SkuToken, _command.SkuToken);
            }

            #endregion
        }
    }
}
