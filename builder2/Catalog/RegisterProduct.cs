using System;
using DesignPatterns.Builder2.Shared;

namespace DesignPatterns.Builder2.Catalog
{
    public record RegisterProduct(
        Guid VendorId,
        string Name,
        string SkuToken
    ) : ICommand;
}
