using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using OrchardCore.ContentManagement;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Catalog.Products;

public class FeaturedProductIndex(string rowId) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
}

public class FeaturedProductIndexProvider : IndexProvider<ContentItem>
{
    public override void Describe(DescribeContext<ContentItem> context)
    {
        context.For<FeaturedProductIndex>()
            .Map(contentItem =>
            {
                if (!contentItem.Published) 
                    return null;
                
                var row = (ProductRow)contentItem.As<ProductPart>()?.Row;

                if (!row?.Featured ?? true)
                    return null;
    
                return new FeaturedProductIndex(row.Id);
            });
    }
}