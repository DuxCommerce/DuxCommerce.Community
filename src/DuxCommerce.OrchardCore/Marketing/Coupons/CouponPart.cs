using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;

namespace DuxCommerce.OrchardCore.Marketing.Coupons;

public class CouponPart : DuxPart<CouponRow>
{
    public sealed override CouponRow Row { get; set; } = new();
}