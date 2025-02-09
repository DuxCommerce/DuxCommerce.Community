using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Shipping.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Shipping.ShippingOrigins;

public class ShippingOriginIndex(string rowId, bool isDefault) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public bool IsDefault { get; set; } = isDefault;
}

public class ShippingOriginIndexProvider : IndexProvider<ShippingOriginPart>
{
    public override void Describe(DescribeContext<ShippingOriginPart> context)
    {
        context.For<ShippingOriginIndex>()
            .Map(x =>
            {
                var row = (ShippingOriginRow)x.Row;

                return new ShippingOriginIndex(row.Id, row.IsDefault);
            });
    }
}