using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Extensions;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Shared.VmBuilders;

public class CategoryPickerVmBuilder(ICategoryStore categoryStore)
{
    public async Task<CategoryPickerVm> BuildModel(List<string> idsExcluded)
    {
        var contentItems = (await categoryStore.GetAllItems<ContentItem>()).ToList();

        return new CategoryPickerVm
        {
            CategoryTrails = contentItems.ToCategoryTrails(),
            CategoryMap = contentItems.ToDictionary(x => x.ContentItemId),
            IdsExcluded = idsExcluded
        };
    }
}