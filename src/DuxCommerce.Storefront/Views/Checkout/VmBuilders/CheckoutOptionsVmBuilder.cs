using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Carts.Requests;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.Checkout.Requests;
using DuxCommerce.StoreBuilder.Checkout.UseCases;
using DuxCommerce.Storefront.Views.Checkout.ViewModels;

namespace DuxCommerce.Storefront.Views.Checkout.VmBuilders;

public class CheckoutOptionsVmBuilder(
    CartUseCases cartUseCases,
    CheckoutUseCases checkoutUseCases,
    MiniCartVmBuilder miniCartVmBuilder)
{
    public async Task<CheckoutOptionsVm> BuildViewModel(ShopperInfo shopperInfo)
    {
        var cart = await cartUseCases.GetCart(shopperInfo);

        var checkoutOptions = await checkoutUseCases.GetCheckoutOptions(shopperInfo);

        return new CheckoutOptionsVm
        {
            Steps = new CheckoutStepsVm { CheckoutOptions = true },
            ShippingOptions = checkoutOptions.ShippingOptions,
            ShippingModel = ToShippingOptionModel(cart),
            PaymentMethods = checkoutOptions.PaymentMethods,
            MethodModel = ToPaymentModel(cart),
            MiniCart = await miniCartVmBuilder.GetMiniCart(cart)
        };
    }

    public async Task<CheckoutOptionsVm> BuildViewModel(ShopperInfo shopperInfo, CheckoutOptionsVm model)
    {
        model.Steps = new CheckoutStepsVm { CheckoutOptions = true };

        var cart = await cartUseCases.GetCart(shopperInfo);
        model.MiniCart = await miniCartVmBuilder.GetMiniCart(cart);

        var checkoutOptions = await checkoutUseCases.GetCheckoutOptions(shopperInfo);
        model.ShippingOptions = checkoutOptions.ShippingOptions;
        model.PaymentMethods = checkoutOptions.PaymentMethods;

        return model;
    }

    private static ShippingOptionModel ToShippingOptionModel(CartRow cart)
    {
        return new ShippingOptionModel
        {
            ProfileId = cart.ShippingProfileId,
            MethodId = cart.ShippingMethodId,
            MethodName = cart.ShippingMethodName,
            ShippingFee = cart.ShippingFee
        };
    }

    private static PaymentMethodModel ToPaymentModel(CartRow cart)
    {
        return new PaymentMethodModel
        {
            MethodType = cart.PaymentMethodType,
            MethodName = cart.PaymentMethodName
        };
    }
}