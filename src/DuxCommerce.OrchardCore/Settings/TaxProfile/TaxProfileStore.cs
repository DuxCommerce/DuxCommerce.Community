using DuxCommerce.OrchardCore.Settings.StoreProfile;
using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.Constants;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Settings.TaxProfile;

public class TaxProfileStore(ISession session, IIdGenerator generator) : PartStore(session, generator), ITaxProfileStore
{
    public async Task<string> Create(TaxProfileRow row)
    {
        return await base.Create<TaxProfilePart, TaxProfileRow>(row);
    }

    public async Task<TaxProfileRow> Get(string id)
    {
        return await base.Get<TaxProfilePart, TaxProfileRow, StoreSettingsIndex>(id);
    }

    public async Task<TaxProfileRow> GetProfile()
    {
        var part = await Session
            .Query<TaxProfilePart, StoreSettingsIndex>(x => x.Name == SettingNames.TaxProfile)
            .FirstOrDefaultAsync();

        return part.Row;
    }

    public async Task<bool> Update(TaxProfileRow row)
    {
        return await base.Update<TaxProfilePart, TaxProfileRow, StoreSettingsIndex>(row);
    }
}