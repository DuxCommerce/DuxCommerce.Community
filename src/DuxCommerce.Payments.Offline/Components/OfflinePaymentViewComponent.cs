using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.Payments.Offline.Views.Shared.Components.OfflinePayment;
using Microsoft.AspNetCore.Mvc;

namespace DuxCommerce.Payments.Offline.Components;

public class OfflinePaymentViewComponent(OfflinePaymentVmBuilder offlinePaymentVmBuilder) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(ShopperInfo shopperInfo)
    {
        var model = await offlinePaymentVmBuilder.BuildViewModel(shopperInfo);
        
        return View(model);
    }
}