using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Services;

public class ProductSearchOptionsFactory(CategoryUseCases categoryUseCases)
{
    public async Task<ProductSearchOptions> CreateSearchOptions(ProductSearchVm searchVm,
        IEnumerable<string> excludedProductIds)
    {
        var limitedToProductIds = (List<string>)null;

        if (!string.IsNullOrEmpty(searchVm.SelectedCategoryId))
            limitedToProductIds = (await categoryUseCases.GetProductIds(searchVm.SelectedCategoryId)).ToList();

        return new ProductSearchOptions
        {
            ProductName = searchVm.ProductName,
            ExcludedProductIds = excludedProductIds,
            LimitedToProductIds = limitedToProductIds
        };
    }
}