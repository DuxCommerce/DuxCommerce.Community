using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using OrchardCore.ContentManagement;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Catalog.Products;

public class ProductCategoryIndex(
    string rowId,
    string categoryId) : DuxIndex
{
    public ProductCategoryIndex() : this(string.Empty, string.Empty)
    {
    }

    public sealed override string RowId { get; set; } = rowId;
    public string CategoryId { get; set; } = categoryId;
}

public class ProductCategoryIndexProvider : IndexProvider<ContentItem>
{
    public override void Describe(DescribeContext<ContentItem> context)
    {
        context.For<ProductCategoryIndex>()
            .Map(contentItem =>
            {
                if (!contentItem.Latest) 
                    return null;

                if (!contentItem.Published) 
                    return null;
                
                var row = (ProductRow)contentItem.As<ProductPart>()?.Row;

                if (row == null)
                    return null;

                var categoryIds = row.CategoryIds ?? Array.Empty<string>();

                return categoryIds.Select(id => new ProductCategoryIndex(row.Id, id));
            });
    }
}