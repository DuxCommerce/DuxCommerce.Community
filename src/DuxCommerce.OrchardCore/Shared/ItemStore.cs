using DuxCommerce.StoreBuilder.Settings.DataTypes;
using OrchardCore.ContentManagement;
using YesSql;
using YesSql.Services;

namespace DuxCommerce.OrchardCore.Shared;

public class ItemStore
{
    protected readonly ISession Session;

    protected ItemStore(ISession session)
    {
        Session = session;
    }

    protected async Task<TRow> Get<TPart, TRow, TIndex>(string id)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
        var contentItem = await GetItem<TIndex>(id);
        
        return contentItem.As<TPart>().Row;
    }

    protected async Task<IEnumerable<TRow>> GetMany<TPart, TRow, TIndex>(IEnumerable<string> ids)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
        var contentItems = await GetItems<TIndex>(ids);
        
        return contentItems.Select(item => item.As<TPart>().Row);
    }
    
    protected async Task<IEnumerable<TRow>> GetChildren<TPart, TRow, TIndex>(string parentId)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex, IParent
    {
        var contentItems = await Session
            .Query<ContentItem, TIndex>(x => x.ParentId == parentId)
            .ListAsync();

        return contentItems.Select(item => item.As<TPart>().Row);
    }

    protected async Task<bool> Update<TPart, TRow, TIndex>(TRow row) 
        where TRow : IRow
        where TPart : DuxPart<TRow>, new()
        where TIndex : DuxIndex
    {
        var contentItem = await GetItem<TIndex>(row.Id);
        contentItem.Alter<TPart>(part => part.Row = row);

        await Session.SaveAsync(contentItem);

        return true;
    }

    protected async Task<bool> UpdateMany<TPart, TRow, TIndex>(IEnumerable<TRow> rows)
        where TRow : IRow
        where TPart : DuxPart<TRow>, new()
        where TIndex : DuxIndex
    {
        var rowsToUpdate = rows.ToList();

        var contentItems = await GetItems<TIndex>(rowsToUpdate.Select(x => x.Id));

        foreach (var contentItem in contentItems)
        {
            var targetRow = rowsToUpdate.First(x => x.Id == contentItem.ContentItemId);
            contentItem.Alter<TPart>(part => part.Row = targetRow);
            await Session.SaveAsync(contentItem);
        }

        return true;
    }

    protected async Task DeleteItem<TIndex>(string id)
        where TIndex : DuxIndex
    {
        var contentItem = await GetItem<TIndex>(id);

        Session.Delete(contentItem);
    }

    protected async Task DeleteMany<TIndex>(IEnumerable<string> ids)
        where TIndex : DuxIndex
    {
        var contentItems = await GetItems<TIndex>(ids);

        DeleteMany(contentItems);
    }

    private void DeleteMany(IEnumerable<ContentItem> contentItems)
    {
        foreach (var contentItem in contentItems)
            Session.Delete(contentItem);
    }

    private async Task<ContentItem> GetItem<TIndex>(string id) 
        where TIndex : DuxIndex
    {
        return await Session.Query<ContentItem, TIndex>(x => x.RowId == id)
            .FirstOrDefaultAsync();
    }

    private async Task<IEnumerable<ContentItem>> GetItems<TIndex>(IEnumerable<string> ids) 
        where TIndex : DuxIndex
    {
        return await Session
            .Query<ContentItem, TIndex>(x => x.RowId.IsIn(ids))
            .ListAsync();
    }
}