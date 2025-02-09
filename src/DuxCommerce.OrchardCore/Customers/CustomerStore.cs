using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Customers.DataStores;
using DuxCommerce.StoreBuilder.Customers.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Customers;

public class CustomerStore(ISession session, IIdGenerator generator) : PartStore(session, generator), ICustomerStore
{
    public async Task<string> Create(CustomerRow row)
    {
        return await base.Create<CustomerPart, CustomerRow>(row);
    }

    public async Task<CustomerRow> Get(string id)
    {
        return await base.Get<CustomerPart, CustomerRow, CustomerIndex>(id);
    }

    public async Task<IEnumerable<CustomerRow>> GetAll()
    {
        return await base.GetAll<CustomerRow, CustomerPart>();
    }

    public async Task<CustomerRow?> GetByUserId(string userId)
    {
        var part = await Session
            .Query<CustomerPart, CustomerIndex>(x => x.UserId == userId)
            .FirstOrDefaultAsync();

        return part?.Row!;
    }

    public async Task<bool> Update(CustomerRow row)
    {
        return await base.Update<CustomerPart, CustomerRow, CustomerIndex>(row);
    }

    public async Task<bool> Delete(string id)
    {
        return await base.Delete<CustomerPart, CustomerRow, CustomerIndex>(id);
    }
}