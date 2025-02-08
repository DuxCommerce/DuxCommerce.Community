using System;

namespace DuxCommerce.Storefront.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ToLocalTime(this DateTime utcDateTime, TimeZoneInfo timeZone)
    {
        var dateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);

        return TimeZoneInfo.ConvertTime(dateTime, timeZone);
    }

    public static DateTime ToUtcTime(this DateTime localDateTime, TimeZoneInfo timeZone)
    {
        var dateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Unspecified);

        return TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZone);
    }
}