using System;
using System.Linq;
using System.Security.Claims;
using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.Storefront.Extensions;
using Microsoft.AspNetCore.Http;

namespace DuxCommerce.Storefront.Views.Checkout.VmBuilders;

public class ShopperInfoProvider(IHttpContextAccessor httpContextAccessor) : IShopperInfoProvider
{
    public ShopperInfo Get()
    {
        return new ShopperInfo { CartId = GetShopperCartId(), Email = GetUserEmail(), UserId = GetUserId() };
    }

    public string GetUserId()
    {
        return GetClaimValue(ClaimTypes.NameIdentifier);
    }

    private string GetUserEmail()
    {
        return GetClaimValue(ClaimTypes.Email);
    }

    private string GetClaimValue(string claimName)
    {
        var user = httpContextAccessor?.HttpContext?.User;

        if (user?.Identity is { IsAuthenticated: true })
        {
            var emailClaim = user.Claims.SingleOrDefault(x => x.Type == claimName);

            if (emailClaim != null)
                return emailClaim.Value;
        }

        return string.Empty;
    }

    private string GetShopperCartId()
    {
        var cartId = httpContextAccessor.HttpContext.GetShopperCartId();

        if (cartId != null)
            return cartId;

        cartId = Guid.NewGuid().ToString();
        httpContextAccessor.HttpContext.SetShopperCartId(cartId);

        return cartId;
    }
}