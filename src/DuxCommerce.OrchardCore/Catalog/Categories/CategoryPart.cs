using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.OrchardCore.Catalog.Categories;

public class CategoryPart : DuxPart<CategoryRow>
{
    public sealed override CategoryRow Row { get; set; } = new CategoryRow();
}