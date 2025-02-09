using DuxCommerce.OrchardCore.Shared;

namespace DuxCommerce.OrchardCore.Settings.StoreProfile;

public class StoreSettingsIndex(string rowId, string name) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string Name { get; set; } = name;
}