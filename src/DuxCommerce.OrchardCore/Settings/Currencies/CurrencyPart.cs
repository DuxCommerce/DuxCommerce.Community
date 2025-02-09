using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.OrchardCore.Settings.Currencies;

public class CurrencyPart : DuxPart<CurrencyRow>
{
    public sealed override CurrencyRow Row { get; set; } = new();
}