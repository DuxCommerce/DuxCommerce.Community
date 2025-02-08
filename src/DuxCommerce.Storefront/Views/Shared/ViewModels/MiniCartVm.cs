using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Shared.ViewModels;

public class MiniCartVm
{
    public CartRow Cart { get; set; }
    public bool BreakDownTax { get; set; }
    public IEnumerable<ItemTaxRow> Taxes { get; set; }
    public CurrencyRow Currency { get; set; }
    public IDictionary<string, ContentItem> ProductMap { get; set; }
}