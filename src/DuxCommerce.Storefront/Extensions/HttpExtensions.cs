using Microsoft.AspNetCore.Http;

namespace DuxCommerce.Storefront.Extensions;

public static class HttpExtensions
{
    private const string ShopperCartId = "DuxCommerce.ShopperCartId";

    public static string GetShopperCartId(this HttpContext httpContext)
    {
        var request = httpContext.Request;

        return request.Cookies.ContainsKey(ShopperCartId)
            ? request.Cookies[ShopperCartId]
            : null;
    }

    public static void SetShopperCartId(this HttpContext httpContext, string cartId)
    {
        httpContext.Response.Cookies.Append(ShopperCartId, cartId);
    }
}