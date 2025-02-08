using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.Checkout.UseCases;
using DuxCommerce.StoreBuilder.ErrorTypes;
using PayPalCheckoutSdk.Orders;

namespace DuxCommerce.Payments.PayPal.Services;

public class PayPalPaymentUseCases(
    PayPalPaymentAdapter paypalPaymentAdapter,
    CheckoutUseCases checkoutUseCases)
{
    public async Task<FlexiResult<Order>> CreatePayPalOrder(ShopperInfo shopperInfo)
    {
        var orderResult = await paypalPaymentAdapter.CreateOrder(shopperInfo);

        if (!orderResult.Succeeded)
            return new FlexiResult<Order>(orderResult.Error);
        
        var order = orderResult.Result;
        await checkoutUseCases.UpdatePaymentReference(shopperInfo, order.Id);

        return new FlexiResult<Order>(orderResult.Result);
    }
}