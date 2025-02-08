using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Checkout.Requests;
using DuxCommerce.StoreBuilder.Payments.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Checkout.ViewModels;

public class PaymentMethodsVm
{
    public IEnumerable<PaymentMethodRow> PaymentMethods { get; set; }
    public PaymentMethodModel MethodModel { get; set; }
    public MiniCartVm MiniCart { get; set; }
}