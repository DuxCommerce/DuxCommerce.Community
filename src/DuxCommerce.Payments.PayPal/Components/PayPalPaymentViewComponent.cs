using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.Payments.PayPal.Views.Shared.Components.PayPalPayment;
using Microsoft.AspNetCore.Mvc;

namespace DuxCommerce.Payments.PayPal.Components;

public class PayPalPaymentViewComponent: ViewComponent
{
    private readonly PayPalPaymentVmBuilder _paypalPaymentVmBuilder;

    public PayPalPaymentViewComponent(PayPalPaymentVmBuilder paypalPaymentVmBuilder)
    {
        _paypalPaymentVmBuilder = paypalPaymentVmBuilder;
    }

    public async Task<IViewComponentResult> InvokeAsync(ShopperInfo shopperInfo)
    {
        var model = await _paypalPaymentVmBuilder.BuildViewModel(shopperInfo);
        
        return View(model);
    }
}