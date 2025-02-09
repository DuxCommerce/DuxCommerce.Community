using DuxCommerce.OrchardCore.Orders;
using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Marketing.DataStores;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Marketing.Coupons;

public class CouponStore(ISession session, IIdGenerator generator) : PartStore(session, generator), ICouponStore
{
    public async Task<string> Create(CouponRow row)
    {
        return await base.Create<CouponPart, CouponRow>(row);
    }

    public async Task<CouponRow> Get(string id)
    {
        return await base.Get<CouponPart, CouponRow, CouponIndex>(id);
    }

    public async Task<IEnumerable<CouponRow>> GetAll()
    {
        return await base.GetAll<CouponRow, CouponPart>();
    }

    public async Task<bool> Update(CouponRow row)
    {
        return await base.Update<CouponPart, CouponRow, CouponIndex>(row);
    }

    public async Task<CouponRow?> GetCoupon(string code)
    {
        var part = await Session
            .Query<CouponPart, CouponIndex>(x => x.Code == code)
            .FirstOrDefaultAsync();

        return part?.Row;
    }

    public async Task<bool> Delete(string id)
    {
        return await base.Delete<CouponPart, CouponRow, CouponIndex>(id);
    }

    public async Task<int> CountCode(string couponId, string code)
    {
        var query = Session.Query<CouponPart, CouponIndex>()
            .Where(x => x.RowId != couponId && x.Code == code);

        return await query.CountAsync();
    }

    public async Task<int> GetStoreUsage(string couponId)
    {
        var storeUsageIndex = await Session
            .QueryIndex<CouponUsageIndex>(x => x.CouponId == couponId)
            .FirstOrDefaultAsync();

        return storeUsageIndex?.Count ?? 0;
    }

    public async Task<int> GetCustomerUsage(string userId, string couponId)
    {
        return await Session
            .QueryIndex<CustomerCouponIndex>(x => x.CouponId == couponId && x.UserId == userId)
            .CountAsync();
    }
}