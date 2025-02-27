using System.Collections.Generic;
using System.Linq;
using DuxCommerce.OrchardCore.Catalog.Products;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Extensions;

public static class ProductItemExtensions
{
    public static List<ProductRow> ToProductRows(this IEnumerable<ContentItem> contentItems)
    {
        return contentItems
            .Select(x => x.As<ProductPart>().Row)
            .ToList();
    }
}