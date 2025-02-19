using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Payments.DataTypes;

namespace DuxCommerce.Payments.Offline.Migrations;

public static class PaymentMethodSeedData
{
    private const string ModuleName = "DuxCommerce.Payments.Offline";

    public static IEnumerable<PaymentMethodRow> GetMethods()
    {
        return new List<PaymentMethodRow>
        {
            new()
            {
                DisplayName = "Bank Deposit",
                MethodType = nameof(BankDepositPaymentMethod),
                Instructions = "Bank Deposit Payment Instructions",
                ModuleName = ModuleName
            },
            new()
            {
                DisplayName = "Money Order", 
                MethodType = nameof(MoneyOrderPaymentMethod),
                Instructions = "Money Order Payment Instructions",
                ModuleName = ModuleName
            },
            new()
            {
                DisplayName = "Check", 
                MethodType = nameof(CheckPaymentMethod),
                Instructions = "Check Payment Instructions",
                ModuleName = ModuleName
            },
            new()
            {
                DisplayName = "Cash on Delivery", 
                MethodType = nameof(CashOnDeliveryPaymentMethod),
                Instructions = "Cash on Delivery Instructions",
                ModuleName = ModuleName
            },
            new()
            {
                DisplayName = "Pay in Store", 
                MethodType = nameof(PayInStorePaymentMethod),
                Instructions = "Pay in Store Instructions",
                ModuleName = ModuleName
            }
        };
    }
}