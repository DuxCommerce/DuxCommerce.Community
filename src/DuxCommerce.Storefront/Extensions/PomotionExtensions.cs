using System;
using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;

namespace DuxCommerce.Storefront.Extensions;

public static class PromotionExtensions
{
    public static IEnumerable<string> GetPromotedProducts(this PromotionRow promotion)
    {
        return promotion.Rule?.Product?.Products ?? Array.Empty<string>();
    }

    public static IEnumerable<string> GetPromotedCategories(this PromotionRow promotion)
    {
        return promotion.Rule?.Product?.Categories ?? Array.Empty<string>();
    }
}