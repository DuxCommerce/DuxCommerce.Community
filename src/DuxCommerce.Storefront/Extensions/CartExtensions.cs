using System.Collections.Generic;
using System.Linq;
using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Extensions;

public static class CartExtensions
{
    public static MiniCartVm ToMiniCart(this CartRow cart,
        TaxProfileRow taxProfile,
        CurrencyRow currency,
        IDictionary<string, ContentItem> productMap)
    {
        var taxes = taxProfile.BreakdownTaxOnBackEnd
            ? cart.Items.SelectMany(x => x.Taxes).Summarize()
            : new List<ItemTaxRow>();

        return new MiniCartVm
        {
            Cart = cart,
            BreakDownTax = taxProfile.BreakdownTaxOnFrontEnd,
            Taxes = taxes,
            Currency = currency,
            ProductMap = productMap
        };
    }
}