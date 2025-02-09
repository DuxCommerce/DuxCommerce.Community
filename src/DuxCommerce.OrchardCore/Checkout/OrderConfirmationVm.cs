using DuxCommerce.StoreBuilder.Settings.DataTypes;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.OrchardCore.Checkout;

public class OrderConfirmationVm : ShapeViewModel
{
    public OrderConfirmationVm()
    {
        Metadata.Type = "EmailOrderConfirmation";
    }

    public OrderVm Order { get; set; }
    public StoreProfileRow StoreProfile { get; set; }
}