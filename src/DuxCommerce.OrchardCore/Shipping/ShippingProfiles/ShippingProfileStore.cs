using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Shipping.DataStores;
using DuxCommerce.StoreBuilder.Shipping.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Shipping.ShippingProfiles;

public class ShippingProfileStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), IShippingProfileStore
{
    public async Task<string> Create(ShippingProfileRow row)
    {
        foreach (var group in row.OriginGroups)
            group.Id = IdGenerator.GenerateUniqueId();

        foreach (var zone in row.OriginGroups.SelectMany(x => x.Zones))
            zone.Id = IdGenerator.GenerateUniqueId();

        foreach (var method in row.OriginGroups.SelectMany(x => x.Zones).SelectMany(x => x.Methods))
            method.Id = IdGenerator.GenerateUniqueId();

        foreach (var rate in row.OriginGroups.SelectMany(x => x.Zones).SelectMany(x => x.Methods).SelectMany(x => x.Rates))
            rate.Id = IdGenerator.GenerateUniqueId();

        return await base.Create<ShippingProfilePart, ShippingProfileRow>(row);
    }

    public async Task<ShippingProfileRow> Get(string id)
    {
        return await base.Get<ShippingProfilePart, ShippingProfileRow, ShippingProfileIndex>(id);
    }

    public async Task<ShippingProfileRow> GetDefault()
    {
        var part = await Session
            .Query<ShippingProfilePart, ShippingProfileIndex>(x => x.IsDefault)
            .FirstOrDefaultAsync();

        return part.Row;
    }

    public async Task<IEnumerable<ShippingProfileRow>> GetAll()
    {
        return await base.GetAll<ShippingProfileRow, ShippingProfilePart>();
    }
    
    public async Task<bool> Update(ShippingProfileRow row)
    {
        foreach (var group in row.OriginGroups.Where(x => string.IsNullOrEmpty(x.Id)))
            group.Id = IdGenerator.GenerateUniqueId();

        foreach (var zone in row.OriginGroups.SelectMany(x => x.Zones).Where(x => string.IsNullOrEmpty(x.Id)))
            zone.Id = IdGenerator.GenerateUniqueId();

        foreach (var method in row.OriginGroups.SelectMany(x => x.Zones).SelectMany(x => x.Methods).Where(x => string.IsNullOrEmpty(x.Id)))
            method.Id = IdGenerator.GenerateUniqueId();

        foreach (var rate in row.OriginGroups.SelectMany(x => x.Zones).SelectMany(x => x.Methods).SelectMany(x => x.Rates).Where(x => string.IsNullOrEmpty(x.Id)))
            rate.Id = IdGenerator.GenerateUniqueId();
        
        return await base.Update<ShippingProfilePart, ShippingProfileRow, ShippingProfileIndex>(row);
    }
}