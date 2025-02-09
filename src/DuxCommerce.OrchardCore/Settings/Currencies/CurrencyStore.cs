using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using YesSql.Services;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Settings.Currencies;

public class CurrencyStore(ISession session, IIdGenerator generator) : PartStore(session, generator), ICurrencyStore
{
    public async Task<string> Create(CurrencyRow row)
    {
        return await base.Create<CurrencyPart, CurrencyRow>(row);
    }

    public async Task<CurrencyRow> Get(string id)
    {
        return await base.Get<CurrencyPart, CurrencyRow, CurrencyIndex>(id);
    }

    public async Task<CurrencyRow> GetCurrency(string currencyCode)
    {
        var part = await Session
            .Query<CurrencyPart, CurrencyIndex>(x => x.Code == currencyCode)
            .FirstOrDefaultAsync();

        return part.Row;
    }

    public async Task<IEnumerable<CurrencyRow>> GetCurrencies(IEnumerable<string> countryCodes)
    {
        var parts = await Session
            .Query<CurrencyPart, CurrencyIndex>(x => x.Code.IsIn(countryCodes))
            .ListAsync();

        return parts.Select(x => x.Row);
    }

    public async Task<bool> Update(CurrencyRow row)
    {
        return await base.Update<CurrencyPart, CurrencyRow, CurrencyIndex>(row);
    }

    public async Task<IEnumerable<string>> CreateMany(IEnumerable<CurrencyRow> rows)
    {
        return await base.CreateMany<CurrencyPart, CurrencyRow>(rows);
    }

    public async Task<IEnumerable<CurrencyRow>> GetAll()
    {
        return await base.GetAll<CurrencyRow, CurrencyPart>();
    }

    public async Task<bool> Delete(string id)
    {
        return await Delete<CurrencyPart, CurrencyRow, CurrencyIndex>(id);
    }
}