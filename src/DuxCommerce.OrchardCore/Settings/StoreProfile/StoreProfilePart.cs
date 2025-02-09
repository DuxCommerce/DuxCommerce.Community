using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.OrchardCore.Settings.StoreProfile;

public class StoreProfilePart : DuxPart<StoreProfileRow>
{
    public sealed override StoreProfileRow Row { get; set; } = new();
}