using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Marketing.DataStores;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Marketing.GiftCards;

public class GiftCardStore(ISession session, IIdGenerator generator) : PartStore(session, generator), IGiftCardStore
{
    public async Task<string> Create(GiftCardRow row)
    {
        return await base.Create<GiftCardPart, GiftCardRow>(row);
    }

    public async Task<GiftCardRow> Get(string id)
    {
        return await base.Get<GiftCardPart, GiftCardRow, GiftCardIndex>(id);
    }

    public async Task<bool> Update(GiftCardRow row)
    {
        return await base.Update<GiftCardPart, GiftCardRow, GiftCardIndex>(row);
    }
}