using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Shared;

public class DataSeeder
{
    private readonly IIdGenerator _idGenerator;
    private readonly ISession _session;

    protected DataSeeder(ISession session, IIdGenerator generator)
    {
        _session = session;
        _idGenerator = generator;
    }

    protected async Task CreateMany<TPart, TRow>(IEnumerable<TRow> rows) 
        where TRow: IRow
        where TPart : DuxPart<TRow>, new()
    {
        foreach (var row in rows)
        {
            row.Id = _idGenerator.GenerateUniqueId();
            var part = new TPart { Row = row };

            await _session.SaveAsync(part);
        }
    }
}