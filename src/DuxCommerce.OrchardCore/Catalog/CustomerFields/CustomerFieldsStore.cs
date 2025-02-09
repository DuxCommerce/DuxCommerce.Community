﻿using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Dto;
using YesSql;
using YesSql.Services;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Catalog.CustomerFields;

public class CustomerFieldsStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), ICustomerFieldsStore
{
    public async Task<string> CreateOrUpdate(CustomerFieldsRow row)
    {
        if (string.IsNullOrEmpty(row.Id))
            return await Create<CustomerFieldsPart, CustomerFieldsRow>(row);

        await Update<CustomerFieldsPart, CustomerFieldsRow, CustomerFieldsIndex>(row);

        return row.Id;
    }

    public async Task<CustomerFieldsRow> Get(string id)
    {
        return await base.Get<CustomerFieldsPart, CustomerFieldsRow, CustomerFieldsIndex>(id);    
    }

    public async Task<CustomerFieldsRow> GetFieldList(string productId)
    {
        var part = await Session
            .Query<CustomerFieldsPart, CustomerFieldsIndex>(index => index.ProductId == productId)
            .FirstOrDefaultAsync();

        if (part == null)
            return CustomerFieldsDto.create(productId);

        return (CustomerFieldsRow)part.Row;
    }

    public async Task<IEnumerable<CustomerFieldsRow>> GetFieldLists(IEnumerable<string> productIds)
    {
        var parts = await Session
            .Query<CustomerFieldsPart, CustomerFieldsIndex>(index => index.ProductId.IsIn(productIds))
            .ListAsync();

        return parts.Select(x => x.Row);
    }
}