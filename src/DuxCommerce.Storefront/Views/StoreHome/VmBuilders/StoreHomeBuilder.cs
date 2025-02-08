using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.Storefront.Views.Category.VmBuilders;
using DuxCommerce.Storefront.Extensions;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.StoreHome.VmBuilders;

public class StoreHomeBuilder(
    ICategoryStore categoryStore,
    IProductStore productStore,
    ProductsVmBuilder productsVmBuilder)
{
    public async Task<ViewModels.StoreHome> BuildIndexModel()
    {
        var categoryItems = (await categoryStore.GetAllItems<ContentItem>()).ToList();
        var productItems = (await productStore.GetFeaturedItems<ContentItem>()).ToList();
        var productsVm = await productsVmBuilder.BuildViewModel(productItems);

        return new ViewModels.StoreHome
        {
            MenuVm = categoryItems.ToMenuVm(),
            CategoriesVm = categoryItems.ToFeaturedCategories(),
            ProductsVm = productsVm
        };
    }
}