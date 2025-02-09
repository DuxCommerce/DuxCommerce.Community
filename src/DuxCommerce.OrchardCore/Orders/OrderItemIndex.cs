using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Orders;

public class OrderItemIndex : DuxIndex
{
    public sealed override string RowId { get; set; } = string.Empty;
    public string OrderItemId { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
}

public class OrderItemIndexProvider : IndexProvider<OrderPart>
{
    public override void Describe(DescribeContext<OrderPart> context)
    {
        context.For<OrderItemIndex>()
            .Map(x =>
            {
                var row = x.Row;

                return row.Items.Select(item => new OrderItemIndex
                {
                    RowId = row.Id,
                    OrderItemId = item.Id,
                    ProductId = item.ProductId
                });
            });
    }
}