using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Carts.Requests;
using DuxCommerce.StoreBuilder.Checkout.Requests;
using DuxCommerce.StoreBuilder.Payments.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Checkout.ViewModels;

public class CheckoutOptionsVm
{
    public CheckoutStepsVm Steps { get; set; }
    public IEnumerable<ShippingOptionRow> ShippingOptions { get; set; }
    public IEnumerable<PaymentMethodRow> PaymentMethods { get; set; }
    public MiniCartVm MiniCart { get; set; }
    
    public ShippingOptionModel ShippingModel { get; set; }
    public PaymentMethodModel MethodModel { get; set; }
}