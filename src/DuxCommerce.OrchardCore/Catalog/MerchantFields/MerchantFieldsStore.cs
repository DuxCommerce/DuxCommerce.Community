using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Dto;
using YesSql;
using YesSql.Services;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Catalog.MerchantFields;

public class MerchantFieldsStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), IMerchantFieldsStore
{
    public async Task<string> CreateOrUpdate(MerchantFieldsRow row)
    {
        if (string.IsNullOrEmpty(row.Id))
            return await Create<MerchantFieldsPart, MerchantFieldsRow>(row);

        await Update<MerchantFieldsPart, MerchantFieldsRow, MerchantFieldsIndex>(row);

        return row.Id;
    }

    public async Task<MerchantFieldsRow> Get(string id)
    {
        return await base.Get<MerchantFieldsPart, MerchantFieldsRow, MerchantFieldsIndex>(id);    
    }

    public async Task<MerchantFieldsRow> GetFieldList(string productId)
    {
        var part = await Session
            .Query<MerchantFieldsPart, MerchantFieldsIndex>(index => index.ProductId == productId)
            .FirstOrDefaultAsync();

        if (part == null)
            return MerchantFieldsDto.create(productId);

        return part.Row;
    }

    public async Task<IEnumerable<MerchantFieldsRow>> GetFieldLists(IEnumerable<string> productIds)
    {
        var parts = await Session
            .Query<MerchantFieldsPart, MerchantFieldsIndex>(index => index.ProductId.IsIn(productIds))
            .ListAsync();

        return parts.Select(x => x.Row);
    }
}