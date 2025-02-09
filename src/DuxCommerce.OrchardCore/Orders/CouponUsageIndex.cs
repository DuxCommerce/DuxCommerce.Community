using DuxCommerce.StoreBuilder.Orders.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Orders;

public class CouponUsageIndex : ReduceIndex
{
    public string CouponId { get; set; }
    public int Count { get; set; }
}

public class CouponUsageIndexProvider : IndexProvider<OrderPart>
{
    public override void Describe(DescribeContext<OrderPart> context)
    {
        context.For<CouponUsageIndex>()
            .Map(x =>
            {
                var couponIds = new List<string>();
                
                var row = x.Row;

                if (!string.IsNullOrEmpty(row.CouponId))
                    couponIds.Add(row.CouponId);

                return couponIds.Select(id => new CouponUsageIndex { CouponId = id, Count = 1 });
            })
            .Group(index => index.CouponId)
            .Reduce(group => new CouponUsageIndex()
            {
                CouponId = group.Key,
                Count = group.Sum(x => x.Count)
            })
            .Delete((index, map) =>
            {
                index.Count -= map.Sum(x => x.Count);
                return index.Count > 0 ? index : null;
            });
    }
}