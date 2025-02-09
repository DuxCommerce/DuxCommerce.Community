using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Orders;

public class CustomerCouponIndex : DuxIndex
{
    public sealed override string RowId { get; set; }
    public string UserId { get; set; }
    public string CouponId { get; set; }
}

public class CustomerCouponIndexProvider : IndexProvider<OrderPart>
{
    public override void Describe(DescribeContext<OrderPart> context)
    {
        context.For<CustomerCouponIndex>()
            .Map(x =>
            {
                var row = x.Row;

                if (string.IsNullOrEmpty(row.CouponId))
                    return null;

                return new CustomerCouponIndex { RowId = row.Id, UserId = row.UserId, CouponId = row.CouponId };
            });
    }
}