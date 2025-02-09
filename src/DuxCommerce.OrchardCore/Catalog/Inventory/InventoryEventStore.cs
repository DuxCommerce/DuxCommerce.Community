using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Catalog.Inventory;

public class InventoryEventStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), IInventoryEventStore
{
    public async Task<string> Create(InventoryEventRow row)
    {
        return await base.Create<InventoryEventPart, InventoryEventRow>(row);
    }

    public async Task<InventoryEventRow> Get(string id)
    {
        return await base.Get<InventoryEventPart, InventoryEventRow, InventoryEventIndex>(id);
    }

    public async Task<IEnumerable<string>> CreateMany(IEnumerable<InventoryEventRow> rows)
    {
        return await base.CreateMany<InventoryEventPart, InventoryEventRow>(rows);
    }

    public async Task<IEnumerable<InventoryEventRow>> GetEvents(string productId)
    {
        var parts = await Session
            .Query<InventoryEventPart, InventoryEventIndex>(x => x.ProductId == productId)
            .OrderByDescending(x => x.Id)
            .ListAsync();

        return parts.Select(x => x.Row);
    }
}