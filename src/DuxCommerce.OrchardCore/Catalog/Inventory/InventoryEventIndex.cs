using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Catalog.Inventory;

public class InventoryEventIndex(string rowId, string productId) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string ProductId { get; set; } = productId;
}

public class InventoryEventIndexProvider : IndexProvider<InventoryEventPart>
{
    public override void Describe(DescribeContext<InventoryEventPart> context)
    {
        context.For<InventoryEventIndex>()
            .Map(x =>
            {
                var row = (InventoryEventRow)x.Row;

                return new InventoryEventIndex(row.Id, row.ProductId);
            });
    }
}