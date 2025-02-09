using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;

namespace DuxCommerce.OrchardCore.Marketing.Promotions;

public class PromotionPart : DuxPart<PromotionRow>
{
    public sealed override PromotionRow Row { get; set; } = new();
}