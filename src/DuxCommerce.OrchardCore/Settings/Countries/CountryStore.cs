using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using YesSql.Services;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Settings.Countries;

public class CountryStore(ISession session, IIdGenerator generator) : PartStore(session, generator), ICountryStore
{
    public async Task<string> Create(CountryRow row)
    {
        return await base.Create<CountryPart, CountryRow>(row);
    }

    public async Task<CountryRow> Get(string id)
    {
        return await base.Get<CountryPart, CountryRow, CountryIndex>(id);
    }

    public async Task<bool> Update(CountryRow row)
    {
        return await base.Update<CountryPart, CountryRow, CountryIndex>(row);
    }

    public async Task<IEnumerable<string>> CreateMany(IEnumerable<CountryRow> rows)
    {
        return await base.CreateMany<CountryPart, CountryRow>(rows);
    }

    public async Task<IEnumerable<CountryRow>> GetAll()
    {
        return await base.GetAll<CountryRow, CountryPart>();
    }

    public async Task<CountryRow> GetCountry(string countryCode)
    {
        return (await GetCountries(new List<string> { countryCode })).Single();
    }

    public async Task<IEnumerable<CountryRow>> GetCountries(IEnumerable<string> countryCodes)
    {
        var parts = await Session
            .Query<CountryPart, CountryIndex>(x => x.TwoLetterCode.IsIn(countryCodes))
            .ListAsync();

        return parts.Select(x => x.Row);
    }

    public async Task<bool> Delete(string id)
    {
        return await Delete<CountryPart, CountryRow, CountryIndex>(id);
    }

    public async Task<bool> UpdateMany(IEnumerable<CountryRow> rows)
    {
        return await UpdateMany<CountryPart, CountryRow, CountryIndex>(rows);
    }

    public async Task<IEnumerable<CountryRow>> GetEnabledCountries()
    {
        var parts = await Session
            .Query<CountryPart, CountryIndex>(x => x.BillingEnabled || x.ShippingEnabled)
            .ListAsync();

        return parts.Select(x => x.Row);
    }

    public async Task<IEnumerable<CountryRow>> GetBillingCountries()
    {
        var parts = await Session
            .Query<CountryPart, CountryIndex>(x => x.BillingEnabled)
            .ListAsync();

        return parts.Select(x => x.Row);
    }

    public async Task<IEnumerable<CountryRow>> GetShippingCountries()
    {
        var parts = await Session
            .Query<CountryPart, CountryIndex>(x => x.ShippingEnabled)
            .ListAsync();

        return parts.Select(x => x.Row);
    }
}