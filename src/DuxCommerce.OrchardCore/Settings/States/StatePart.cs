using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.OrchardCore.Settings.States;

public class StatePart : DuxPart<StateRow>
{
    public sealed override StateRow Row { get; set; } = new();
}