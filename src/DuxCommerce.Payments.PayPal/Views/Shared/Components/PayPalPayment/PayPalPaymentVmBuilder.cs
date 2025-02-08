using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.Payments.PayPal.DataStores;

namespace DuxCommerce.Payments.PayPal.Views.Shared.Components.PayPalPayment;

public class PayPalPaymentVmBuilder(
    IPayPalSettingsStore payPalSettingsStore,
    CartUseCases cartUseCases)
{
    public async Task<PayPalPaymentVm> BuildViewModel(ShopperInfo shopperInfo)
    {
        var cart = await cartUseCases.GetCart(shopperInfo);
        
        var settings = await payPalSettingsStore.GetSettings();

        return new PayPalPaymentVm
        {
            ClientId = settings.ClientId,
            Currency = cart.PaymentCurrency,
            Environment = settings.IsTestMode ? "sandbox" : "production"
        };
    }
}