using System;
using System.Collections.Generic;

namespace DuxCommerce.Payments.Stripe.Services;

// https://stripe.com/docs/currencies
public class StripeAmount
{
    private static readonly List<string> ZeroDecimalCurrencies = new()
    {
        "BIF",
        "CLP",
        "DJF",
        "GNF",
        "JPY",
        "KMF",
        "KRW",
        "MGA",
        "PYG",
        "RWF",
        "UGX",
        "VND",
        "VUV",
        "XAF",
        "XOF",
        "XPF"
    };

    private static readonly List<string> SpecialCurrencies = new() { "HUF", "TWD", "UGX" };

    public static long Convert(decimal amount, string currency)
    {
        if (ZeroDecimalCurrencies.Contains(currency))
            return (long)Math.Round(amount);

        if (SpecialCurrencies.Contains(currency))
            return (long)(Math.Round(amount) * 100);

        return (long)Math.Round(amount * 100);
    }
}