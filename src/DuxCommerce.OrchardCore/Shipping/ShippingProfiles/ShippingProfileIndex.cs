using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Shipping.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Shipping.ShippingProfiles;

public class ShippingProfileIndex(string rowId, bool isDefault) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public bool IsDefault { get; set; } = isDefault;
}

public class ShippingProfileIndexProvider : IndexProvider<ShippingProfilePart>
{
    public override void Describe(DescribeContext<ShippingProfilePart> context)
    {
        context.For<ShippingProfileIndex>()
            .Map(x =>
            {
                var row = (ShippingProfileRow)x.Row;

                return new ShippingProfileIndex(row.Id, row.IsDefault);
            });
    }
}