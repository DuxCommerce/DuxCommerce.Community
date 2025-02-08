using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.Checkout.UseCases;
using DuxCommerce.StoreBuilder.ErrorTypes;

namespace DuxCommerce.Payments.Stripe.Services;

public class StripePaymentUseCases(
    StripePaymentAdapter stripePaymentAdapter,
    CheckoutUseCases checkoutUseCases)
{
    public async Task<FlexiResult<string>> InitPayment(ShopperInfo shopperInfo)
    {
        var initResult = await stripePaymentAdapter.InitPayment(shopperInfo);

        if (!initResult.Succeeded)
            return new FlexiResult<string>(initResult.Error);

        await checkoutUseCases.UpdatePaymentReference(shopperInfo, initResult.Result.PaymentIntentId);

        return new FlexiResult<string>(initResult.Result.ClientSecret);
    }
}