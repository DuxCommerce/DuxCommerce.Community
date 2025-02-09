using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Taxes.DataStores;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Taxes.TaxCodes;

public class TaxCodeStore(ISession session, IIdGenerator generator) : PartStore(session, generator), ITaxCodeStore
{
    public async Task<string> Create(TaxCodeRow row)
    {
        return await base.Create<TaxCodePart, TaxCodeRow>(row);
    }

    public async Task<TaxCodeRow> Get(string id)
    {
        return await base.Get<TaxCodePart, TaxCodeRow, TaxCodeIndex>(id);
    }

    public async Task<IEnumerable<TaxCodeRow>> GetAll()
    {
        return await base.GetAll<TaxCodeRow, TaxCodePart>();
    }

    public async Task<bool> Update(TaxCodeRow row)
    {
        return await base.Update<TaxCodePart, TaxCodeRow, TaxCodeIndex>(row);
    }

    public async Task<bool> Delete(string id)
    {
        return await Delete<TaxCodePart, TaxCodeRow, TaxCodeIndex>(id);
    }
}