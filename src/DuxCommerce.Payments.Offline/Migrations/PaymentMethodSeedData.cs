using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Payments.DataTypes;

namespace DuxCommerce.Payments.Offline.Migrations;

public static class PaymentMethodSeedData
{
    public static IEnumerable<PaymentMethodRow> GetMethods()
    {
        const string offlineController = "PaymentMethod";
        const string offlineAction = "Setup";

        return new List<PaymentMethodRow>
        {
            new()
            {
                DisplayName = "Bank Deposit",
                MethodType = nameof(BankDepositPaymentMethod),
                SetupController = offlineController,
                SetupAction = offlineAction,
                Instructions = "Bank Deposit Payment Instructions",
            },
            new()
            {
                DisplayName = "Money Order", 
                MethodType = nameof(MoneyOrderPaymentMethod),
                SetupController = offlineController,
                SetupAction = offlineAction,
                Instructions = "Money Order Payment Instructions",
            },
            new()
            {
                DisplayName = "Check", 
                MethodType = nameof(CheckPaymentMethod),
                SetupController = offlineController,
                SetupAction = offlineAction,
                Instructions = "Check Payment Instructions",
            },
            new()
            {
                DisplayName = "Cash on Delivery", 
                MethodType = nameof(CashOnDeliveryPaymentMethod),
                SetupController = offlineController,
                SetupAction = offlineAction,
                Instructions = "Cash on Delivery Instructions",
            },
            new()
            {
                DisplayName = "Pay in Store", 
                MethodType = nameof(PayInStorePaymentMethod),
                SetupController = offlineController,
                SetupAction = offlineAction,
                Instructions = "Pay in Store Instructions",
            }
        };
    }
}