using System;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.Storefront.Extensions;

namespace DuxCommerce.Storefront.Views.AdminOrder.VmBuilders;

public static class SearchOptionsExtensions
{
    public static OrderSearchOptions Preprocess(this OrderSearchOptions options, TimeZoneInfo timeZone)
    {
        if (options.StartTime.HasValue)
        {
            var startTime = options.StartTime.Value.ToUtcTime(timeZone);
            options.StartTime = startTime;
        }

        if (options.EndTime.HasValue)
        {
            var endTime = options.EndTime.Value.ToUtcTime(timeZone);
            options.EndTime = endTime;
        }

        return options;
    }
}