using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.Storefront.Views.AdminProduct.ViewModels;
using DuxCommerce.Storefront.Views.LinkedOption.ViewModels;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.LinkedOption.VmBuilders;

public class LinkedOptionVmBuilder(
    IProductStore productStore,
    IProductOptionsStore productOptionsStore,
    IOptionStore optionStore)
{
    public async Task<LinkedOptionVm> BuildEditModel(string productId, string optionId)
    {
        var productOptions = await productOptionsStore.GetByProductId(productId);
        var sharedOption = await optionStore.Get(optionId);
        var productItem = await productStore.GetItem<ContentItem>(productId);

        return new LinkedOptionVm
        {
            Links = new ProductLinksVm { ContentItem = productItem, OptionsLink = true },
            ProductOptions = productOptions,
            SharedOption = sharedOption
        };
    }
}