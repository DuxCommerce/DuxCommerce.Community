using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using OrchardCore.ContentManagement;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Catalog.Categories;

public class CategoryIndex(
    string rowId,
    string name,
    int sortOrder,
    string parentId,
    bool featured)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string Name { get; set; } = name;
    public int SortOrder { get; set; } = sortOrder;
    public string ParentId { get; set; } = parentId;
    public bool Featured { get; set; } = featured;
}

public class CategoryIndexProvider : IndexProvider<ContentItem>
{
    public override void Describe(DescribeContext<ContentItem> context)
    {
        context.For<CategoryIndex>()
            .Map(x =>
            {
                var row = x.As<CategoryPart>()?.Row;

                if (row == null)
                    return null;

                return new CategoryIndex(
                    row.Id,
                    row.Name,
                    row.SortOrder,
                    row.ParentId,
                    row.Featured);
            });
    }
}