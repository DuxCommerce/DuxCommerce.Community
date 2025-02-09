using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using YesSql.Services;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Settings.States;

public class StateStore(ISession session, IIdGenerator generator) : PartStore(session, generator), IStateStore
{
    public async Task<string> Create(StateRow row)
    {
        return await base.Create<StatePart, StateRow>(row);
    }

    public async Task<StateRow> Get(string id)
    {
        return await base.Get<StatePart, StateRow, StateIndex>(id);
    }

    public async Task<bool> Update(StateRow row)
    {
        return await base.Update<StatePart, StateRow, StateIndex>(row);
    }

    public async Task<IEnumerable<string>> CreateMany(IEnumerable<StateRow> rows)
    {
        return await base.CreateMany<StatePart, StateRow>(rows);
    }
    
    public async Task<IEnumerable<StateRow>> GetMany(IEnumerable<string> ids)
    {
        return await base.GetMany<StatePart, StateRow, StateIndex>(ids);
    }    

    public async Task<IEnumerable<StateRow>> GetStates(string countryCode)
    {
        var parts = await Session
            .Query<StatePart, StateIndex>(x => x.CountryCode == countryCode)
            .ListAsync();

        return parts.Select(x => x.Row);
    }

    public async Task<IEnumerable<StateRow>> GetStates(IEnumerable<string> countryCodes)
    {
        var parts = await Session
            .Query<StatePart, StateIndex>(x => x.CountryCode.IsIn(countryCodes))
            .ListAsync();

        return parts.Select(x => x.Row);
    }

    public async Task<bool> Delete(string id)
    {
        return await Delete<StatePart, StateRow, StateIndex>(id);
    }
}