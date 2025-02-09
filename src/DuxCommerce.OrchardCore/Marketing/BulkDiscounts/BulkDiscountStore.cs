using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using YesSql;
using YesSql.Services;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Marketing.BulkDiscounts;

public class BulkDiscountStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), IBulkDiscountStore
{
    public async Task<string> Create(BulkDiscountRow row)
    {
        return await base.Create<BulkDiscountPart, BulkDiscountRow>(row);
    }

    public async Task<BulkDiscountRow> Get(string id)
    {
        return await base.Get<BulkDiscountPart, BulkDiscountRow, BulkDiscountIndex>(id);
    }

    public async Task<bool> Update(BulkDiscountRow row)
    {
        return await base.Update<BulkDiscountPart, BulkDiscountRow, BulkDiscountIndex>(row);
    }

    public async Task<IEnumerable<BulkDiscountRow>> GetDiscounts(IEnumerable<string> productIds)
    {
        var parts = await Session
            .Query<BulkDiscountPart, BulkDiscountIndex>(x => x.ProductId.IsIn(productIds))
            .ListAsync();

        return parts.Select(x => x.Row);
    }
}