using DuxCommerce.StoreBuilder.Settings.DataTypes;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.OrchardCore.Checkout;

public class OrderNotificationVm : ShapeViewModel
{
    public OrderNotificationVm()
    {
        Metadata.Type = "EmailOrderNotification";
    }

    public OrderVm OrderVm { get; set; }
    public StoreProfileRow StoreProfile { get; set; }
}