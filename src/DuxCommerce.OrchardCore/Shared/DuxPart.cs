using DuxCommerce.StoreBuilder.Settings.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.OrchardCore.Shared;

public abstract class DuxPart<TRow> : ContentPart
    where TRow : IRow
{
    public abstract TRow Row { get; set; }
}