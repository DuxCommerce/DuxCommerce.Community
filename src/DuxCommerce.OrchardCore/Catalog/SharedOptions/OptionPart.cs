using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.OrchardCore.Catalog.SharedOptions;

public class OptionPart : DuxPart<OptionRow>
{
    public sealed override OptionRow Row { get; set; } = new();
}