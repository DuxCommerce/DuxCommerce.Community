using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Carts;

public class CartIndex(
    string rowId,
    string shopperCartId,
    DateTime lastUpdatedUtc,
    DateTime createdAtUtc)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string ShopperCartId { get; set; } = shopperCartId;
    public DateTime LastUpdatedUtc { get; set; } = lastUpdatedUtc;
    public DateTime CreatedAtUtc { get; set; } = createdAtUtc;
}

public class CartIndexProvider : IndexProvider<CartPart>
{
    public override void Describe(DescribeContext<CartPart> context)
    {
        context.For<CartIndex>()
            .Map(x =>
            {
                var row = (CartRow)x.Row;

                return new CartIndex(
                    row.Id,
                    row.ShopperCartId,
                    row.LastUpdatedUtc,
                    row.CreatedAtUtc);
            });
    }
}