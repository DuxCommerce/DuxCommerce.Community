using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.Storefront.Views.StoreHome.ViewModels;
using DuxCommerce.Storefront.Extensions;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Builders;

public class CategoryMenuBuilder(ICategoryStore categoryStore)
{
    public async Task<CategoryMenuVm> Build()
    {
        var contentItems = (await categoryStore.GetAllItems<ContentItem>()).ToList();

        return contentItems.ToMenuVm();
    }
}