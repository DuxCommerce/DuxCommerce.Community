using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Settings.Countries;

public interface ICountrySeeder
{
    Task CreateMany(IEnumerable<CountryRow> rows);
}

public class CountrySeeder(
    ISession session,
    IIdGenerator generator) : DataSeeder(session, generator), ICountrySeeder
{
    public async Task CreateMany(IEnumerable<CountryRow> rows)
    {
        await CreateMany<CountryPart, CountryRow>(rows);
    }
}