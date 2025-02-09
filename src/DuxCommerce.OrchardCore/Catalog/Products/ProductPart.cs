using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.OrchardCore.Catalog.Products;

public class ProductPart : DuxPart<ProductRow>
{
    public sealed override ProductRow Row { get; set; } = new();
}