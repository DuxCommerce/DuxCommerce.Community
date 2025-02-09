using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Shipping.DataTypes;

namespace DuxCommerce.OrchardCore.Shipping.ShippingOrigins;

public class ShippingOriginPart : DuxPart<ShippingOriginRow>
{
    public sealed override ShippingOriginRow Row { get; set; } = new();
}