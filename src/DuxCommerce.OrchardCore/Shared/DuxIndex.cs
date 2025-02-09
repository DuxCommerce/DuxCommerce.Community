using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Shared;

public abstract class DuxIndex : MapIndex
{
    public abstract string RowId { get; set; }
}