using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.ShoppingCart.ViewModels;

public class ShoppingCartVm
{
    public CurrencyRow Currency { get; set; }
    public CartRow Cart { get; set; }
    public IDictionary<string, ContentItem> ItemMap { get; set; }
}