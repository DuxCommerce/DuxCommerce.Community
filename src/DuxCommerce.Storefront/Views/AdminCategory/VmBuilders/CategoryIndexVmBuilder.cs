using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.Storefront.Views.AdminCategory.ViewModels;
using DuxCommerce.Storefront.Extensions;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.AdminCategory.VmBuilders;

public class CategoryIndexVmBuilder(ICategoryStore categoryStore)
{
    public async Task<CategoryIndexVm> BuildModel()
    {
        var contentItems = (await categoryStore.GetAllItems<ContentItem>()).ToList();

        return new CategoryIndexVm
        {
            CategoryTrails = contentItems.ToCategoryTrails(),
            CategoryMap = contentItems.ToDictionary(x => x.ContentItemId)
        };
    }
}