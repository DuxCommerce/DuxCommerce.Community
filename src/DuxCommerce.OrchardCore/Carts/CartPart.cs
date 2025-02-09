using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Carts.DataTypes;

namespace DuxCommerce.OrchardCore.Carts;

public class CartPart : DuxPart<CartRow>
{
    public sealed override CartRow Row { get; set; } = new();
}