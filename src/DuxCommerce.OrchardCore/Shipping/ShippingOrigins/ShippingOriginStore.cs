using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Shipping.DataStores;
using DuxCommerce.StoreBuilder.Shipping.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Shipping.ShippingOrigins;

public class ShippingOriginStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), IShippingOriginStore
{
    public async Task<string> Create(ShippingOriginRow row)
    {
        var addressId = IdGenerator.GenerateUniqueId();
        row.Address.Id = addressId;

        return await base.Create<ShippingOriginPart, ShippingOriginRow>(row);
    }

    public async Task<ShippingOriginRow> Get(string id)
    {
        return await base.Get<ShippingOriginPart, ShippingOriginRow, ShippingOriginIndex>(id);
    }

    public async Task<ShippingOriginRow> GetDefault()
    {
        var part = await Session
            .Query<ShippingOriginPart, ShippingOriginIndex>(x => x.IsDefault)
            .FirstOrDefaultAsync();

        return part.Row;
    }

    public async Task<bool> Update(ShippingOriginRow row)
    {
        return await base.Update<ShippingOriginPart, ShippingOriginRow, ShippingOriginIndex>(row);
    }

    public async Task<IEnumerable<ShippingOriginRow>> GetMany(IEnumerable<string> ids)
    {
        return await base.GetMany<ShippingOriginPart, ShippingOriginRow, ShippingOriginIndex>(ids);
    }
}