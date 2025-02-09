using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.OrchardCore.Settings.TaxProfile;

public class TaxProfilePart : DuxPart<TaxProfileRow>
{
    public sealed override TaxProfileRow Row { get; set; } = new();
}