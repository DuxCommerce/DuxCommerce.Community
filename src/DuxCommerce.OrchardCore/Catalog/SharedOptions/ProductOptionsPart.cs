using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.OrchardCore.Catalog.SharedOptions;

public class ProductOptionsPart : DuxPart<ProductOptionsRow>
{
    public sealed override ProductOptionsRow Row { get; set; } = new();
}