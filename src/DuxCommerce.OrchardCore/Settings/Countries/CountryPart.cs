using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.OrchardCore.Settings.Countries;

public class CountryPart : DuxPart<CountryRow>
{
    public sealed override CountryRow Row { get; set; } = new();
}