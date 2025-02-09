using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Shipping.DataTypes;

namespace DuxCommerce.OrchardCore.Shipping.ShippingProfiles;

public class ShippingProfilePart : DuxPart<ShippingProfileRow>
{
    public sealed override ShippingProfileRow Row { get; set; } = new();
}