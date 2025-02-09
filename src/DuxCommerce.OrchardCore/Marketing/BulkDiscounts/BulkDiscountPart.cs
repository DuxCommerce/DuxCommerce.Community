using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.OrchardCore.Marketing.BulkDiscounts;

public class BulkDiscountPart : DuxPart<BulkDiscountRow>
{
    public sealed override BulkDiscountRow Row { get; set; } = new();
}