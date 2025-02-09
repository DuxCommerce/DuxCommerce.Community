using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Taxes.TaxCodes;

public interface ITaxCodeSeeder
{
    Task CreateMany(IEnumerable<TaxCodeRow> rows);
}

public class TaxCodeSeeder(
    ISession session,
    IIdGenerator generator) : DataSeeder(session, generator), ITaxCodeSeeder
{
    public async Task CreateMany(IEnumerable<TaxCodeRow> rows)
    {
        await CreateMany<TaxCodePart, TaxCodeRow>(rows);
    }
}

public static class TaxCodeSeedData
{
    public static IEnumerable<TaxCodeRow> GetCodes()
    {
        var result = new List<TaxCodeRow> { new() { Name = "Taxable", IsDefault = true } };

        return result;
    }
}