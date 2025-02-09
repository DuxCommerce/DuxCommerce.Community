using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Carts;

public class CartItemIndex : DuxIndex
{
    public sealed override string RowId { get; set; } = string.Empty;
    public string CartItemId { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
}

public class CartItemIndexProvider : IndexProvider<CartPart>
{
    public override void Describe(DescribeContext<CartPart> context)
    {
        context.For<CartItemIndex>()
            .Map(x =>
            {
                var row = (CartRow)x.Row;

                return row.Items.Select(item => new CartItemIndex
                {
                    RowId = row.Id,
                    CartItemId = item.CartItemId,
                    ProductId = item.ProductId
                });
            });
    }
}