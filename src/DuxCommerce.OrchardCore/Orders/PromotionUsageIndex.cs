using DuxCommerce.StoreBuilder.Orders.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Orders;

public class PromotionUsageIndex : ReduceIndex
{
    public string PromotionId { get; set; }
    public int Count { get; set; }
}

public class PromotionUsageIndexProvider : IndexProvider<OrderPart>
{
    public override void Describe(DescribeContext<OrderPart> context)
    {
        context.For<PromotionUsageIndex>()
            .Map(x =>
            {
                var row = x.Row;
                
                var promotionIds = row.PromotionIds ?? [];
                return promotionIds.Select(id => new PromotionUsageIndex { PromotionId = id, Count = 1 });
            })
            .Group(index => index.PromotionId)
            .Reduce(group => new PromotionUsageIndex()
            {
                PromotionId = group.Key,
                Count = group.Sum(x => x.Count)
            })
            .Delete((index, map) =>
            {
                index.Count -= map.Sum(x => x.Count);
                return index.Count > 0 ? index : null;
            });
    }
}