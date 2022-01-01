using System;

namespace DesignPatterns.Builder2.Read
{
    public record Product(
        Guid Id,
        string Name,
        decimal Price
    )
    {
        public static Product Pants = new(Guid.NewGuid(), "Pants", 24.99m);
        public static Product Shirt = new(Guid.NewGuid(), "Shirt", 12.99m);
    }
}
