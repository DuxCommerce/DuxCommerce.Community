using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Catalog.SharedOptions;

public class OptionStore(ISession session, IIdGenerator generator) : PartStore(session, generator), IOptionStore
{
    public async Task<string> Create(OptionRow row)
    {
        return await base.Create<OptionPart, OptionRow>(row);
    }

    public async Task<OptionRow> Get(string id)
    {
        return await base.Get<OptionPart, OptionRow, OptionIndex>(id);
    }

    public async Task<IEnumerable<OptionRow>> GetAll()
    {
        return await base.GetAll<OptionRow, OptionPart>();
    }

    public async Task<bool> Update(OptionRow row)
    {
        PopulateIdsIf(row);
        
        return await base.Update<OptionPart, OptionRow, OptionIndex>(row);
    }

    public async Task<bool> Delete(string id)
    {
        return await base.Delete<OptionPart, OptionRow, OptionIndex>(id);
    }
    
    public async Task<IEnumerable<OptionRow>> GetMany(IEnumerable<string> ids)
    {
        return await base.GetMany<OptionPart, OptionRow, OptionIndex>(ids);
    }    
    
    private void PopulateIdsIf(OptionRow row)
    {
        foreach (var choice in row.Choices)
        {
            if (string.IsNullOrEmpty(choice.Id))
                choice.Id = IdGenerator.GenerateUniqueId();
        }
    }    
}