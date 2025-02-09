using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.Constants;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Settings.StoreProfile;

public class StoreProfileStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), IStoreProfileStore
{
    public async Task<string> Create(StoreProfileRow row)
    {
        return await base.Create<StoreProfilePart, StoreProfileRow>(row);
    }

    public async Task<StoreProfileRow> Get(string id)
    {
        return await base.Get<StoreProfilePart, StoreProfileRow, StoreSettingsIndex>(id);
    }

    public async Task<StoreProfileRow> GetProfile()
    {
        var part = await Session
            .Query<StoreProfilePart, StoreSettingsIndex>(x => x.Name == SettingNames.StoreProfile)
            .FirstOrDefaultAsync();

        return part.Row;
    }

    public async Task<bool> Update(StoreProfileRow row)
    {
        return await base.Update<StoreProfilePart, StoreProfileRow, StoreSettingsIndex>(row);
    }
}