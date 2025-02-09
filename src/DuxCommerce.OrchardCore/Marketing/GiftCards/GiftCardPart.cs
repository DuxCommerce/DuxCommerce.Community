using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;

namespace DuxCommerce.OrchardCore.Marketing.GiftCards;

public class GiftCardPart : DuxPart<GiftCardRow>
{
    public sealed override GiftCardRow Row { get; set; } = new();
}