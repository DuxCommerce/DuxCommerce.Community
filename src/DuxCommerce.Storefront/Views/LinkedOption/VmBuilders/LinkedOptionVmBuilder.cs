using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.Storefront.Views.LinkedOption.ViewModels;

namespace DuxCommerce.Storefront.Views.LinkedOption.VmBuilders;

public class LinkedOptionVmBuilder(IProductOptionsStore productOptionsStore, IOptionStore optionStore)
{
    public async Task<LinkedOptionVm> BuildEditModel(string productId, string optionId)
    {
        var productOptions = await productOptionsStore.GetByProductId(productId);
        var sharedOption = await optionStore.Get(optionId);
        var linkedOption = productOptions.SharedOptions.First(x => x.OptionId == optionId);

        return new LinkedOptionVm
        {
            ProductOptions = productOptions,
            SharedOption = sharedOption,
            LinkedOption = linkedOption
        };
    }
}