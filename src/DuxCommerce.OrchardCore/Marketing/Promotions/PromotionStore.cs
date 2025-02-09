using DuxCommerce.OrchardCore.Orders;
using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Marketing.DataStores;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using YesSql;
using YesSql.Services;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Marketing.Promotions;

public class PromotionStore(ISession session, IIdGenerator generator) : PartStore(session, generator), IPromotionStore
{
    public async Task<string> Create(PromotionRow row)
    {
        return await base.Create<PromotionPart, PromotionRow>(row);
    }

    public async Task<PromotionRow> Get(string id)
    {
        return await base.Get<PromotionPart, PromotionRow, PromotionIndex>(id);
    }

    public async Task<IEnumerable<PromotionRow>> GetAll()
    {
        return await base.GetAll<PromotionRow, PromotionPart>();
    }

    public async Task<bool> Update(PromotionRow row)
    {
        return await base.Update<PromotionPart, PromotionRow, PromotionIndex>(row);
    }

    public async Task<IEnumerable<PromotionRow>> GetActives()
    {
        var now = DateTime.UtcNow;
        
        var parts = await Session
            .Query<PromotionPart, PromotionIndex>(x => x.Activated && x.StartTime <= now && x.EndTime > now)
            .ListAsync();

        return parts.Select(x => x.Row);
    }

    public async Task<IEnumerable<PromotionRow>> GetMany(IEnumerable<string> ids)
    {
        return await base.GetMany<PromotionPart, PromotionRow, PromotionIndex>(ids);
    }

    public async Task<bool> UpdateMany(IEnumerable<PromotionRow> rows)
    {
        return await base.UpdateMany<PromotionPart, PromotionRow, PromotionIndex>(rows);
    }

    public async Task<bool> DeleteMany(IEnumerable<string> ids)
    {
        await base.DeleteMany<PromotionPart, PromotionRow, PromotionIndex>(ids);

        return true;
    }

    public async Task<bool> Delete(string id)
    {
        return await base.Delete<PromotionPart, PromotionRow, PromotionIndex>(id);
    }

    public async Task<IEnumerable<PromotionUsage>> GetStoreUsage(IEnumerable<string>? promotionIds)
    {
        if (promotionIds == null || !promotionIds.Any())
            return new List<PromotionUsage>();
        
        var storeUsageIndices = await Session
            .QueryIndex<PromotionUsageIndex>(x => x.PromotionId.IsIn(promotionIds))
            .ListAsync();

        return (storeUsageIndices ?? new List<PromotionUsageIndex>())
            .Select(x => new PromotionUsage { PromotionId = x.PromotionId, Count = x.Count });
    }

    public async Task<IEnumerable<string>> GetCustomerUsage(string userId, IEnumerable<string>? promotionIds)
    {
        if (promotionIds == null || !promotionIds.Any())
            return new List<string>();

        var customerUsageIndices = await Session
            .QueryIndex<CustomerPromotionIndex>(x => x.PromotionId.IsIn(promotionIds) && x.UserId == userId)
            .ListAsync();

        return customerUsageIndices.Select(x => x.PromotionId);
    }
}