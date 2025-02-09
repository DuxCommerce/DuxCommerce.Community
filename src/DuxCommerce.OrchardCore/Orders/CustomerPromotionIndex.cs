using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Orders;

public class CustomerPromotionIndex : DuxIndex
{
    public sealed override string RowId { get; set; }
    public string UserId { get; set; }
    public string PromotionId { get; set; }
}

public class CustomerPromotionIndexProvider : IndexProvider<OrderPart>
{
    public override void Describe(DescribeContext<OrderPart> context)
    {
        context.For<CustomerPromotionIndex>()
            .Map(x =>
            {
                var row = (OrderRow)x.Row;

                return (row.PromotionIds ?? Array.Empty<string>())
                    .Select(id => new CustomerPromotionIndex { RowId = row.Id, UserId = row.UserId, PromotionId = id });
            });
    }
}