using DuxCommerce.StoreBuilder.Payments.DataStores;

namespace DuxCommerce.OrchardCore.Payments;

public class SettingsUseCases(IPaymentMethodStore paymentMethodStore)
{
    public async Task<string> GetInstructions(string methodType)
    {
        var paymentMethod = await paymentMethodStore.GetMethod(methodType);

        return paymentMethod.Instructions;
    }

    public async Task UpdateMethod(PaymentMethodSettings request)
    {
        var paymentMethod = await paymentMethodStore.GetMethod(request.MethodType);

        paymentMethod.DisplayName = request.DisplayName;
        paymentMethod.Instructions = request.Instructions;
        paymentMethod.DisplayOrder = request.DisplayOrder;
        paymentMethod.AvailableCountries = request.AvailableCountries.ToArray();

        await paymentMethodStore.Update(paymentMethod);
    }
}