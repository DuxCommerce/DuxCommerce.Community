using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.Plugins;
using DuxCommerce.Storefront.Views.Checkout.ViewModels;

namespace DuxCommerce.Storefront.Views.Checkout.VmBuilders;

public class ConfirmPaymentVmBuilder(
    CartUseCases cartUseCases,
    MiniCartVmBuilder miniCartVmBuilder,
    IEnumerable<IPaymentMethod> paymentMethods)
{
    public async Task<ConfirmPaymentVm> BuildViewModel(ShopperInfo shopperInfo)
    {
        var cart = await cartUseCases.GetCart(shopperInfo);

        var paymentMethod = paymentMethods.Single(x => x.MethodType == cart.PaymentMethodType);

        return new ConfirmPaymentVm
        {
            Steps = new CheckoutStepsVm { ConfirmPayment = true },
            ShopperInfo = shopperInfo,
            CheckoutViewComponent = paymentMethod.CheckoutViewComponent,
            MiniCart = await miniCartVmBuilder.GetMiniCart(cart)
        };
    }
}