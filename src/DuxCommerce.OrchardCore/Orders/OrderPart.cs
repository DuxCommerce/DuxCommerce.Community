using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Orders.DataTypes;

namespace DuxCommerce.OrchardCore.Orders;

public class OrderPart : DuxPart<OrderRow>
{
    public sealed override OrderRow Row { get; set; } = new();
}