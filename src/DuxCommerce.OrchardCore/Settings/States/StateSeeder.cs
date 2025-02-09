using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Settings.States;

public class StateSeeder(
    ISession session,
    IIdGenerator generator) : DataSeeder(session, generator), IStateSeeder
{
    public async Task CreateMany(IEnumerable<StateRow> rows)
    {
        await CreateMany<StatePart, StateRow>(rows);
    }
}