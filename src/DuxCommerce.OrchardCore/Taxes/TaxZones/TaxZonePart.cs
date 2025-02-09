using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;

namespace DuxCommerce.OrchardCore.Taxes.TaxZones;

public class TaxZonePart : DuxPart<TaxZoneRow>
{
    public sealed override TaxZoneRow Row { get; set; } = new();
}