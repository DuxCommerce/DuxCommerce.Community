using System;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Plugins;
using DuxCommerce.StoreBuilder.ErrorTypes;
using DuxCommerce.Payments.Offline.Components;

namespace DuxCommerce.Payments.Offline;

public abstract class OfflinePaymentMethod : IPaymentMethod
{
    public abstract string MethodType { get; }

    public Type CheckoutViewComponent => typeof(OfflinePaymentViewComponent);
        
    public async Task<DuxResult<PaymentResult>> ChargeAsync(IPaymentRequest request)
    {
        return new DuxResult<PaymentResult>(new PaymentResult());
    }
}

public class BankDepositPaymentMethod : OfflinePaymentMethod
{
    public override string MethodType => nameof(BankDepositPaymentMethod);
}

public class MoneyOrderPaymentMethod : OfflinePaymentMethod
{
    public override string MethodType => nameof(MoneyOrderPaymentMethod);
}

public class CheckPaymentMethod : OfflinePaymentMethod
{
    public override string MethodType => nameof(CheckPaymentMethod);
}

public class CashOnDeliveryPaymentMethod : OfflinePaymentMethod
{
    public override string MethodType => nameof(CashOnDeliveryPaymentMethod);
}

public class PayInStorePaymentMethod : OfflinePaymentMethod
{
    public override string MethodType => nameof(PayInStorePaymentMethod);
}