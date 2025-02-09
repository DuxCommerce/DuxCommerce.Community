using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.SimpleTypes;
using DuxCommerce.StoreBuilder.SimpleTypes;
using OrchardCore.ContentManagement;
using YesSql;
using YesSql.Services;

namespace DuxCommerce.OrchardCore.Catalog.Products;

public class ProductStore(ISession session, IContentManager contentManager) : ItemStore(session), IProductStore
{
    public async Task<bool> HasOptions(string id)
    {
        var count = await Session
            .QueryIndex<ProductIndex>(x => x.HasOptions && x.RowId == id)
            .CountAsync();

        return count > 0;
    }

    public async Task<ProductRow> Get(string id)
    {
        return await base.Get<ProductPart, ProductRow, ProductIndex>(id);
    }

    public async Task<bool> Update(ProductRow row)
    {
        return await base.Update<ProductPart, ProductRow, ProductIndex>(row);
    }

    public async Task<IEnumerable<string>> CreateMany(string parentId, IEnumerable<ProductRow> rows)
    {
        var rowIds = new List<string>();
        
        var parentItem = await contentManager.GetAsync(parentId, VersionOptions.Published);
        
        foreach (var row in rows)
        {
            var contentItem = await contentManager.CloneAsync(parentItem);

            row.Id = contentItem.ContentItemId;

            contentItem.Alter<ProductPart>(part => part.Row = row);

            await contentManager.UpdateAsync(contentItem);

            await contentManager.PublishAsync(contentItem);
            
            rowIds.Add(row.Id);
        }

        return rowIds;
    }

    public async Task<IEnumerable<ProductRow>> GetMany(IEnumerable<string> ids)
    {
        return await base.GetMany<ProductPart, ProductRow, ProductIndex>(ids);
    }

    public async Task<TContentItem> GetItem<TContentItem>(string id) where TContentItem : class
    {
        return await Session
            .Query<TContentItem, ProductIndex>(index => index.RowId == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TContentItem>> GetManyItems<TContentItem>(IEnumerable<string> ids) 
        where TContentItem : class
    {
        return await Session
            .Query<TContentItem, ProductIndex>(index => index.RowId.IsIn(ids))
            .ListAsync();
    }
    
    public async Task<IEnumerable<ProductRow>> GetVariants(string parentId)
    {
        return await GetChildren<ProductPart, ProductRow, ProductIndex>(parentId);
    }

    public async Task<bool> UpdateMany(IEnumerable<ProductRow> rows)
    {
        return await base.UpdateMany<ProductPart, ProductRow, ProductIndex>(rows);
    }

    public async Task<bool> Delete(string id)
    {
        await DeleteItem<ProductIndex>(id);

        return true;
    }

    public async Task<bool> DeleteMany(IEnumerable<string> ids)
    {
        await base.DeleteMany<ProductIndex>(ids);

        return true;
    }

    public async Task<IEnumerable<ProductRow>> GetByCategories(IEnumerable<string> categoryIds)
    {
        var contentItems = await Session
            .Query<ContentItem, ProductCategoryIndex>(x => x.CategoryId.IsIn(categoryIds))
            .ListAsync();

        return contentItems
            .Select(x => x.As<ProductPart>())
            .Select(x => x.Row);
    }

    public async Task<IEnumerable<string>> GetIdsByCategory(string categoryId)
    {
        var indexes = await Session
            .QueryIndex<ProductCategoryIndex>(x => x.CategoryId == categoryId)
            .ListAsync();

        return indexes.Select(x => x.RowId);
    }

    public async Task<IEnumerable<string>> GetVariantIds(string parentId, IEnumerable<string> choiceIds)
    {
        var indexes = await Session.QueryIndex<ProductChoiceIndex>(index =>
                index.ChoiceId.IsIn(choiceIds) && index.ParentId == parentId)
            .ListAsync();

        return indexes.Select(x => x.RowId);
    }

    public async Task<IEnumerable<string>> GetAllVariantIds(string parentId)
    {
        var indexes = await Session.QueryIndex<ProductChoiceIndex>(index => index.ParentId == parentId)
            .ListAsync();

        return indexes.Select(x => x.RowId);
    }

    public async Task<IEnumerable<string>> GetIdsByChoices(IEnumerable<string> choiceIds)
    {
        var indexes = await Session
            .QueryIndex<ProductChoiceIndex>(x => x.ChoiceId.IsIn(choiceIds.ToList()))
            .ListAsync();

        return indexes.Select(x => x.RowId);
    }

    public async Task<IEnumerable<TContentItem>> FilterProducts<TContentItem>(ProductFilterOptions filterOptions, Pagination pagerParams) 
        where TContentItem : class
    {
        var filterQuery = Session.Query<TContentItem, ProductIndex>(index =>
            index.RowId.IsIn(filterOptions.ProductIds)
            && index.IsVisible);

        var query = SortProducts(filterQuery, filterOptions.SortOption);

        return await query.Skip(pagerParams.StartIndex).Take(pagerParams.PageSize).ListAsync();
    }

    public async Task<int> CountProducts(IEnumerable<string> productIds)
    {
        return await Session.Query<ContentItem, ProductIndex>(index =>
                index.RowId.IsIn(productIds) && index.IsVisible)
            .CountAsync();
    }

    public async Task<int> CountSkus(IEnumerable<string> productIds, IEnumerable<string> skus)
    {
        var ids = productIds.ToList();
        var query = Session.QueryIndex<ProductIndex>();

        if (ids.Any())
            query = query.Where(x => x.RowId.IsNotIn(ids));

        return await query.Where(x => x.Sku.IsIn(skus)).CountAsync();
    }
    
    private IQuery<TContentItem, ProductIndex> SortProducts<TContentItem> (IQuery<TContentItem, ProductIndex> query, ProductSortOption sortOption)
        where TContentItem : class
    {
        switch (sortOption)
        {
            case ProductSortOption.NameZToA:
                return query.OrderByDescending(x => x.Name);
            
            case ProductSortOption.PriceLowToHigh:
                return query.OrderBy(x => x.Price);
            
            case ProductSortOption.PriceHighToLow:
                return query.OrderByDescending(x => x.Price);
            
            default:
                return query.OrderBy(x => x.Name);
        }
    }

    public async Task<IEnumerable<TContentItem>> GetFeaturedItems<TContentItem>() where TContentItem : class
    {
        return await Session.Query<TContentItem, FeaturedProductIndex>().ListAsync();
    }
}