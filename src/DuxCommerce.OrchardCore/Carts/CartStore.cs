using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Carts.DataStores;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using YesSql;
using YesSql.Services;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Carts;

public class CartStore(ISession session, IIdGenerator generator) : PartStore(session, generator), ICartStore
{
    public async Task<string> Create(CartRow row)
    {
        return await base.Create<CartPart, CartRow>(row);
    }

    public async Task<bool> Update(CartRow row)
    {
        if (row.ShippingAddress != null && row.ShippingAddress.Id == null)
            row.ShippingAddress.Id = IdGenerator.GenerateUniqueId();
        
        if (row.BillingAddress != null && row.BillingAddress.Id == null)
            row.BillingAddress.Id = IdGenerator.GenerateUniqueId();

        var cartItems = row.Items.Where(x => string.IsNullOrEmpty(x.CartItemId));
        
        foreach (var cartItem in cartItems)
            cartItem.CartItemId = IdGenerator.GenerateUniqueId();
        
        return await base.Update<CartPart, CartRow, CartIndex>(row);
    }

    public async Task<bool> UpdateMany(IEnumerable<CartRow> rows)
    {
        return await UpdateMany<CartPart, CartRow, CartIndex>(rows);
    }

    public async Task<CartRow?> GetCart(string cartId)
    {
        var part = await GetCartPart(cartId);

        return part?.Row;
    }

    public async Task<bool> DeleteCart(string cartId)
    {
        var part = await GetCartPart(cartId);

        if (part != null)
            Session.Delete(part);

        return true;
    }

    public async Task<IEnumerable<CartRow>> GetCarts(IEnumerable<string> productIds)
    {
        var parts = await Session
            .Query<CartPart, CartItemIndex>(x => x.ProductId.IsIn(productIds))
            .ListAsync();

        return parts.Select(x => x.Row);
    }
    
    public async Task<bool> CartExists(string cartId)
    {
        var cart = await GetCart(cartId);
        
        return cart != null && cart.Items.Length != 0;
    } 
    
    private async Task<CartPart?> GetCartPart(string cartId)
    {
        return await Session
            .Query<CartPart, CartIndex>(x => x.ShopperCartId == cartId)
            .FirstOrDefaultAsync();
    }
}