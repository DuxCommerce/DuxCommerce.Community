using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.OrchardCore.Catalog.Inventory;

public class InventoryEventPart : DuxPart<InventoryEventRow>
{
    public sealed override InventoryEventRow Row { get; set; } = new();
}