using System;
using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.AdminOrder.ViewModels;

public class OrderShipmentsVm
{
    public OrderRow Order { get; set; }
    public IDictionary<string, ContentItem> ProductMap { get; set; }
    public ShipmentModel Shipment { get; set; }
    public CurrencyRow Currency { get; set; }
    public OrderLinks Links { get; set; }
    public TimeZoneInfo TimeZone { get; set; }
}