using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Builders;

public class OrdersVmBuilder(ICurrencyStore currencyStore)
{
    public async Task<OrdersVm> BuildViewModel(List<OrderRow> orders, TimeZoneInfo timeZone)
    {
        var currencyCodes = orders.Select(x => x.PaymentCurrency).Distinct();
        var currencies = await currencyStore.GetCurrencies(currencyCodes);

        var orderVms = orders.Select(x =>
            new OrderVm
            {
                Order = x,
                Currency = currencies.Single(c => c.Code == x.PaymentCurrency),
                IsAdminOrder = true
            });

        return new OrdersVm { Orders = orderVms, TimeZone = timeZone };
    }
}