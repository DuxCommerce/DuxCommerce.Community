using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using YesSql;

namespace DuxCommerce.OrchardCore.Catalog.Categories;

public class CategoryStore(ISession session) : ItemStore(session), ICategoryStore
{
    public async Task<CategoryRow> Get(string id)
    {
        return await base.Get<CategoryPart, CategoryRow, CategoryIndex>(id);
    }

    public async Task<TContentItem> GetItem<TContentItem>(string id)
        where TContentItem : class
    {
        return await Session
            .Query<TContentItem, CategoryIndex>(index => index.RowId == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CategoryRow>> GetAll()
    {
        var allItems = await GetAllItems<ContentItem>();

        return allItems.Select(x => x.As<CategoryPart>().Row);
    }

    public async Task<IEnumerable<TContentItem>> GetAllItems<TContentItem>()
        where TContentItem : class
    {
        var query = Session.Query<TContentItem, ContentItemIndex>(x => x.ContentType == ContentType.Category);

        return await query.ListAsync();
    }

    public async Task<bool> Delete(string id)
    {
        await DeleteItem<CategoryIndex>(id);

        return true;
    }

    public async Task<bool> DeleteMany(IEnumerable<string> ids)
    {
        await base.DeleteMany<CategoryIndex>(ids);
        
        return true;
    }
}