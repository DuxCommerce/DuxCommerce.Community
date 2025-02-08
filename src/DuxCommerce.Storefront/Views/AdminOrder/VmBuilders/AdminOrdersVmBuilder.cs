using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Orders.DataStores;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.StoreBuilder.Orders.SimpleTypes;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using DuxCommerce.Storefront.Builders;
using DuxCommerce.Storefront.Views.AdminOrder.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using OrchardCore.DisplayManagement;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Views.AdminOrder.VmBuilders;

public class AdminOrdersVmBuilder(
    StoreProfileUseCases storeProfileUseCases,
    IOrderStore orderStore,
    IShapeFactory shapeFactory,
    OrdersVmBuilder ordersVmBuilder)
{
    private readonly dynamic _new = shapeFactory;

    public async Task<AdminOrdersVm> Build(OrderSearchOptions searchOptions, PagerParameters pagerParameters)
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();

        var pager = new Pager(pagerParameters, 10);
        var updatedOptions = searchOptions.Preprocess(timeZone);
        var orders = (await orderStore.SearchOrders(updatedOptions, pager.GetStartIndex(), pager.PageSize)).ToList();

        var count = await orderStore.CountOrders(searchOptions);
        var pagerShape = (await _new.Pager(pager)).TotalItemCount(count).RouteData(new RouteData());

        var ordersVm = await ordersVmBuilder.BuildViewModel(orders, timeZone);

        return new AdminOrdersVm
        {
            OrdersVm = ordersVm,
            Pager = pagerShape,
            OrderStatuses = GetOrderStatuses(),
            PaymentStatuses = GetPaymentStatuses(),
            ShippingStatuses = GetShippingStatuses()
        };
    }

    private IEnumerable<SelectListItem> GetOrderStatuses()
    {
        var types = new List<(string, string)>
        {
            (string.Empty, "Any Status"),
            (nameof(OrderStatus.Open), nameof(OrderStatus.Open)),
            (nameof(OrderStatus.Completed), nameof(OrderStatus.Completed)),
            (nameof(OrderStatus.Archived), nameof(OrderStatus.Archived)),
            (nameof(OrderStatus.Canceled), nameof(OrderStatus.Canceled))
        };

        return types.Select(x => new SelectListItem(x.Item2, x.Item1));
    }

    private IEnumerable<SelectListItem> GetPaymentStatuses()
    {
        var types = new List<(string, string)>
        {
            (string.Empty, "Any Status"),
            (nameof(PaymentStatus.Pending), nameof(PaymentStatus.Pending)),
            (nameof(PaymentStatus.Authorized), nameof(PaymentStatus.Authorized)),
            (nameof(PaymentStatus.Expired), nameof(PaymentStatus.Expired)),
            (nameof(PaymentStatus.OverDue), nameof(PaymentStatus.OverDue)),
            (nameof(PaymentStatus.Paid), nameof(PaymentStatus.Paid)),
            (nameof(PaymentStatus.PartiallyPaid), "Partially Paid"),
            (nameof(PaymentStatus.Refunded), nameof(PaymentStatus.Refunded)),
            (nameof(PaymentStatus.PartiallyRefunded), "Partially Refunded"),
            (nameof(PaymentStatus.Voided), nameof(PaymentStatus.Voided)),
            (nameof(PaymentStatus.Failed), nameof(PaymentStatus.Failed))
        };

        return types.Select(x => new SelectListItem(x.Item2, x.Item1));
    }

    private IEnumerable<SelectListItem> GetShippingStatuses()
    {
        var types = new List<(string, string)>
        {
            (string.Empty, "Any Status"),
            (nameof(ShippingStatus.Unshipped), nameof(ShippingStatus.Unshipped)),
            (nameof(ShippingStatus.PartiallyShipped), "Partially Shipped"),
            (nameof(ShippingStatus.Shipped), nameof(ShippingStatus.Shipped))
        };

        return types.Select(x => new SelectListItem(x.Item2, x.Item1));
    }
}