using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.Payments.Stripe.Services;
using DuxCommerce.Payments.Stripe.Views.Shared.Components.StripePayment;
using Microsoft.AspNetCore.Mvc;

namespace DuxCommerce.Payments.Stripe.Components;

public class StripePaymentViewComponent(
    StripePaymentUseCases stripePaymentUseCases,
    StripePaymentVmBuilder stripePaymentVmBuilder)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(ShopperInfo shopperInfo)
    {
        var initResult = await stripePaymentUseCases.InitPayment(shopperInfo);
        
        // Todo: should we check returned result and display error message on UI?
        
        var model = await stripePaymentVmBuilder.BuildViewModel(initResult.Result);
        
        return View(model);
    }
}