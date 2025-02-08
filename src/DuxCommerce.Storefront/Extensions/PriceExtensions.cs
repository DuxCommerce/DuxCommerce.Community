using System.Globalization;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Storefront.Extensions;

public static class PriceExtensions
{
    public static string ToCurrency(this decimal amount, CurrencyRow currency)
    {
        return string.IsNullOrEmpty(currency.CustomFormatting)
            ? amount.ToString("C", new CultureInfo(currency.DisplayLocale))
            : amount.ToString(currency.CustomFormatting);
    }
}