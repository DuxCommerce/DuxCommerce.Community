using System;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Checkout.ViewModels;

public class ConfirmPaymentVm
{
    public CheckoutStepsVm Steps { get; set; }
    public ShopperInfo ShopperInfo { get; set; }
    public Type CheckoutViewComponent { get; set; }
    public MiniCartVm MiniCart { get; set; }
}