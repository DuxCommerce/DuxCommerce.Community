using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using YesSql.Services;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Shared;

public class PartStore
{
    protected readonly ISession Session;
    protected readonly IIdGenerator IdGenerator;

    protected PartStore(ISession session, IIdGenerator generator)
    {
        Session = session;
        IdGenerator = generator;
    }

    protected async Task<string> Create<TPart, TRow>(TRow row)
        where TRow : IRow
        where TPart : DuxPart<TRow>, new()
    {
        row.Id = IdGenerator.GenerateUniqueId();
        var part = new TPart { Row = row };

        await Session.SaveAsync(part);

        return row.Id;
    }

    protected async Task<IEnumerable<string>> CreateMany<TPart, TRow>(IEnumerable<TRow> rows)
        where TRow : IRow
        where TPart : DuxPart<TRow>, new()
    {
        var ids = new List<string>();

        foreach (var row in rows)
        {
            row.Id = IdGenerator.GenerateUniqueId();
            var part = new TPart { Row = row };

            await Session.SaveAsync(part);

            ids.Add(row.Id);
        }

        return ids;
    }

    protected async Task<TRow> Get<TPart, TRow, TIndex>(string id)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
        var part = await GetPart<TPart, TRow, TIndex>(id);
        return part.Row;
    }

    protected async Task<IEnumerable<TRow>> GetAll<TRow, TPart>()
        where TRow : IRow
        where TPart : DuxPart<TRow>
    {
        var parts = await Session
            .Query<TPart>()
            .ListAsync();

        return parts.Select(part => part.Row);
    }

    protected async Task<IEnumerable<TRow>> GetMany<TPart, TRow, TIndex>(IEnumerable<string> ids)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
        var parts = await GetParts<TPart, TRow, TIndex>(ids);

        return parts.Select(part => part.Row);
    }

    protected async Task<bool> Update<TPart, TRow, TIndex>(TRow row) 
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
        var part = await GetPart<TPart, TRow, TIndex>(row.Id);
        part.Row = row;

        await Session.SaveAsync(part);

        return true;
    }

    protected async Task<bool> UpdateMany<TPart, TRow, TIndex>(IEnumerable<TRow> rows)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
        var rowList = rows.ToList();
        var rowMap = rowList.ToDictionary(x => x.Id);

        var parts = await GetParts<TPart, TRow, TIndex>(rowList.Select(x => x.Id));

        foreach (var part in parts)
        {
            part.Row = rowMap[part.Row.Id];
            await Session.SaveAsync(part);
        }

        return true;
    }

    protected async Task DeleteMany<TPart, TRow, TIndex>(IEnumerable<string> ids)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
            var parts = await GetParts<TPart, TRow, TIndex>(ids);

            foreach (var part in parts)
                Session.Delete(part);
    }

    protected async Task<bool> Delete<TPart, TRow, TIndex>(string id)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
        await DeleteMany<TPart, TRow, TIndex>(new List<string> { id });
        
        return true;
    }

    private async Task<TPart> GetPart<TPart, TRow, TIndex>(string id)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
        return await Session
            .Query<TPart, TIndex>(x => x.RowId == id)
            .FirstOrDefaultAsync();
    }

    private async Task<IEnumerable<TPart>> GetParts<TPart, TRow, TIndex>(IEnumerable<string> ids)
        where TRow : IRow
        where TPart : DuxPart<TRow>
        where TIndex : DuxIndex
    {
        return await Session.Query<TPart, TIndex>(x => x.RowId.IsIn(ids))
            .ListAsync();
    }
}