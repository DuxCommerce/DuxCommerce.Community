using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Payments.DataTypes;

namespace DuxCommerce.Storefront.Views.PaymentMethod.ViewModels;

public class PaymentMethodVm
{
    public IEnumerable<PaymentMethodRow> Methods { get; set; }
}