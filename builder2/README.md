﻿# Builder 2

1. [Pain](#pain)
1. [Use Cases](#use-cases)

## Pain

The builder pattern is frustrating. Understanding its application feels like a neverending spiral into absurdity. Sift through pages of search engine results and read every surface-level example you can - it only ends in disappointment and embarrassment.

## Example

Imagine a `Product` aggregate for the `Catalog` bounded context. Note: properties are primitives for simplicity.

```csharp
namespace Shop.Catalog
{
    public class Product : Aggregate
    {
        string Name { get; private set; }
        string Sku { get; }
        Guid VendorId { get; }
    }
}
```

When a product manager registers a new product using the api, a `RegisterProduct` command is generated.

```csharp
namespace Shop.Api
{
    public record RegisterProduct(
        Guid VendorId,
        string Name,
        string SkuToken
    ) : ICommand
}
```

Business rule:
> When registering the product, the sku is generated from the vendor's sku token and the supplied product sku token.  
e.g. pep-cola, pep-diet

There are a lot of ways to approach creating a new `Product`. Here's a reasonable one:

```csharp
public class Product : Aggregate
{
    public Product(Guid vendorId, string vendorSkuToken, string name, string skuToken)
    {
        Sku = CreateSku(vendorSkuToken, skuToken);
        // assign VendorId and Name
    }
    
    private static string GenerateSku(string vendorSkuToken, string skuToken) => $"{vendorSkuToken}-{skuToken}";
}
```

I like this example for a few reasons:
* Generating the sku isn't trivial
* The vendor's sku token isn't immediately available and will have to be pulled from storage
* `Product` instances are testable and always valid

Business rule:
> A product's name may be altered.

Okay, this is dumb, but let's say it's here for correcting typos or something.

```csharp
namespace Shop.Write.Catalog
{
    public class Product : Entity
    {
        public Guid Id { get; set; }
        public Guid VendorId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
    }
}
```

This is interesting because we need to be able to instantiate a domain `Product` instance, but there are some problems.
* When creating the `Product` instance, we don't want to regenerate the sku, since the 
* Turns out we *can't* calculate the sku anyway, since we don't store the product's sku token
* And we (extra?) can
* We no longer need to calculate the sku, since the product-to-edit will be coming from storage
