using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;

namespace DuxCommerce.OrchardCore.Taxes.TaxCodes;

public class TaxCodePart : DuxPart<TaxCodeRow>
{
    public sealed override TaxCodeRow Row { get; set; } = new();
}