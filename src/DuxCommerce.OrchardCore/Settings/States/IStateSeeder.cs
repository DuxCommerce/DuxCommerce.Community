using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.OrchardCore.Settings.States;

public interface IStateSeeder
{
    Task CreateMany(IEnumerable<StateRow> rows);
}