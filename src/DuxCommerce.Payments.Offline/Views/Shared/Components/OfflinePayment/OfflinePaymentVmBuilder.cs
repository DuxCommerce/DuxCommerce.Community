using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Payments;
using DuxCommerce.StoreBuilder.Carts.UseCases;

namespace DuxCommerce.Payments.Offline.Views.Shared.Components.OfflinePayment;

public class OfflinePaymentVmBuilder(
    SettingsUseCases settingsUseCases,
    CartUseCases cartUseCases)
{
    public async Task<OfflinePaymentVm> BuildViewModel(ShopperInfo shopperInfo)
    {
        var cart = await cartUseCases.GetCart(shopperInfo);

        var instructions = await settingsUseCases.GetInstructions(cart.PaymentMethodType);

        return new OfflinePaymentVm { Instructions = instructions };
    }
}