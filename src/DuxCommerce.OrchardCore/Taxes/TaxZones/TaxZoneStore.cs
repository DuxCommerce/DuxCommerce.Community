using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Taxes.DataStores;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Taxes.TaxZones;

public class TaxZoneStore(ISession session, IIdGenerator generator) : PartStore(session, generator), ITaxZoneStore
{
    public async Task<string> Create(TaxZoneRow row)
    {
        return await base.Create<TaxZonePart, TaxZoneRow>(row);
    }

    public async Task<TaxZoneRow> Get(string id)
    {
        return await base.Get<TaxZonePart, TaxZoneRow, TaxZoneIndex>(id);
    }

    public async Task<IEnumerable<TaxZoneRow>> GetAll()
    {
        return await base.GetAll<TaxZoneRow, TaxZonePart>();
    }

    public async Task<IEnumerable<TaxZoneRow>> GetMany(IEnumerable<string> ids)
    {
        return await base.GetMany<TaxZonePart, TaxZoneRow, TaxZoneIndex>(ids);
    }

    public async Task<bool> Update(TaxZoneRow row)
    {
        var rates = row.Rates.Where(x => string.IsNullOrEmpty(x.Id));

        foreach (var rate in rates)
            rate.Id = IdGenerator.GenerateUniqueId();

        return await base.Update<TaxZonePart, TaxZoneRow, TaxZoneIndex>(row);
    }

    public async Task<bool> Delete(string id)
    {
        return await Delete<TaxZonePart, TaxZoneRow, TaxZoneIndex>(id);
    }
}