using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Products;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using OrchardCore.ContentManagement;
using OrchardCore.Navigation;
using YesSql;
using YesSql.Services;

namespace DuxCommerce.Storefront.Services;

public class ProductService(ISession session)
{
    public async Task<(int, List<ContentItem>)> SearchProducts(ProductSearchOptions options, Pager pager)
    {
        var products = await SearchProducts<ContentItem>(options)
            .Skip(pager.GetStartIndex())
            .Take(pager.PageSize)
            .ListAsync();

        var count = await SearchProducts<ContentItem>(options)
            .CountAsync();

        return (count, products.ToList());
    }

    public async Task<(List<ContentItem>, int)> SearchInventories(ProductSearchOptions options, Pager pager)
    {
        var products = await SearchInventories<ContentItem>(options)
            .Skip(pager.GetStartIndex())
            .Take(pager.PageSize)
            .ListAsync();

        var count = await SearchInventories<ContentItem>(options)
            .CountAsync();

        return (products.ToList(), count);
    }

    public IQuery<TContentItem> GetMany<TContentItem>(IEnumerable<string> productIds) where TContentItem : class
    {
        var query = session.Query<TContentItem, ProductIndex>();

        return query.Where(x => x.RowId.IsIn(productIds));
    }

    private IQuery<TContentItem> SearchProducts<TContentItem>(ProductSearchOptions options) where TContentItem : class
    {
        var query = CreateSearchQuery<TContentItem>(options);

        if (options.ExcludedProductIds != null && options.ExcludedProductIds.Any())
            query = query.Where(x => x.RowId.IsNotIn(options.ExcludedProductIds));

        return query.Where(x => x.ParentId == null);
    }

    private IQuery<TContentItem> SearchInventories<TContentItem>(ProductSearchOptions options)
        where TContentItem : class
    {
        var query = CreateSearchQuery<TContentItem>(options);

        return query.Where(x => !x.HasOptions && x.StockEnabled);
    }

    private IQuery<TContentItem, ProductIndex> CreateSearchQuery<TContentItem>(ProductSearchOptions options)
        where TContentItem : class
    {
        var query = session.Query<TContentItem, ProductIndex>();

        if (!string.IsNullOrEmpty(options.ProductName))
            query = query.Where(x => x.Name.Contains(options.ProductName));

        if (options.LimitedToProductIds != null)
            query = query.Where(x => x.RowId.IsIn(options.LimitedToProductIds));

        return query;
    }
}