using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Settings.Currencies;

public interface ICurrencySeeder
{
    Task CreateMany(IEnumerable<CurrencyRow> rows);
}

public class CurrencySeeder(
    ISession session,
    IIdGenerator generator) : DataSeeder(session, generator), ICurrencySeeder
{
    public async Task CreateMany(IEnumerable<CurrencyRow> rows)
    {
        await CreateMany<CurrencyPart, CurrencyRow>(rows);
    }
}