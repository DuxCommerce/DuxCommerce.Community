using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Orders;

public class OrderIndex(
    string rowId,
    string userId,
    string orderNumber,
    decimal orderTotal,
    string shippingStatus,
    string paymentStatus,
    string orderStatus,
    DateTime lastUpdatedUtc,
    DateTime createdAtUtc)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string UserId { get; set; } = userId;
    public string OrderNumber { get; set; } = orderNumber;
    public decimal OrderTotal { get; set; } = orderTotal;
    public string ShippingStatus { get; set; } = shippingStatus;
    public string PaymentStatus { get; set; } = paymentStatus;
    public string OrderStatus { get; set; } = orderStatus;
    public DateTime LastUpdatedUtc { get; set; } = lastUpdatedUtc;
    public DateTime CreatedAtUtc { get; set; } = createdAtUtc;
}

public class OrderIndexProvider : IndexProvider<OrderPart>
{
    public override void Describe(DescribeContext<OrderPart> context)
    {
        context.For<OrderIndex>()
            .Map(x =>
            {
                var row = (OrderRow)x.Row;

                return new OrderIndex(
                    row.Id,
                    row.UserId,
                    row.OrderNumber,
                    row.OrderTotal,
                    row.ShippingStatus,
                    row.PaymentStatus,
                    row.OrderStatus,
                    row.LastUpdatedUtc,
                    row.CreatedAtUtc);
            });
    }
}