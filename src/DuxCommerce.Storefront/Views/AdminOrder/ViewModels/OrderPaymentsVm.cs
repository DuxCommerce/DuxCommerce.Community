using System;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Storefront.Views.AdminOrder.ViewModels;

public class OrderPaymentsVm
{
    public CurrencyRow Currency { get; set; }
    public OrderRow Order { get; set; }
    public ReceivePaymentModel PaymentModel { get; set; }
    public OrderLinks Links { get; set; }
    public TimeZoneInfo TimeZone { get; set; }
}