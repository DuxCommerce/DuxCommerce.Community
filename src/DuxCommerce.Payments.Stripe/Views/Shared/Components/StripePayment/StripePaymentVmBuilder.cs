using System.Threading.Tasks;
using DuxCommerce.Payments.Stripe.Services;

namespace DuxCommerce.Payments.Stripe.Views.Shared.Components.StripePayment;

public class StripePaymentVmBuilder(StripeSettingsUseCases settingsUseCases)
{
    public async Task<StripePaymentVm> BuildViewModel(string clientSecret)
    {
        var settings = await settingsUseCases.GetSettings();

        return new StripePaymentVm
        {
            ClientSecret = clientSecret,
            PublishableKey = settings.PublishableKey
        };
    }
}