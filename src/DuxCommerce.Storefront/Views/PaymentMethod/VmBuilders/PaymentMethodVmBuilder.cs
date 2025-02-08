using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Payments.DataStores;
using DuxCommerce.Storefront.Views.PaymentMethod.ViewModels;

namespace DuxCommerce.Storefront.Views.PaymentMethod.VmBuilders;

public class PaymentMethodVmBuilder(IPaymentMethodStore methodStore)
{
    public async Task<PaymentMethodVm> BuildIndexModel()
    {
        var methods = await methodStore.GetAll();

        return new PaymentMethodVm { Methods = methods };
    }
}