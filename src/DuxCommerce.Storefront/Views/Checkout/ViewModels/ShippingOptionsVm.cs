using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Carts.Requests;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Checkout.ViewModels;

public class ShippingOptionsVm
{
    public IEnumerable<ShippingOptionRow> ShippingOptions { get; set; }
    public ShippingOptionModel ShippingModel { get; set; }
    public MiniCartVm MiniCart { get; set; }

    public string Warning { get; set; }
}