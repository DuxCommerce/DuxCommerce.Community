using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.OrchardCore.Checkout;

public class OrderVm : ShapeViewModel
{
    public OrderVm()
    {
        Metadata.Type = "Order";
    }

    public OrderRow Order { get; set; }
    public CurrencyRow Currency { get; set; }
    public IDictionary<string, ContentItem> ProductMap { get; set; }
    public List<ItemTaxRow> Taxes { get; set; }
    public bool BreakDownTax { get; set; }
    public bool IsAdminOrder { get; set; }
}