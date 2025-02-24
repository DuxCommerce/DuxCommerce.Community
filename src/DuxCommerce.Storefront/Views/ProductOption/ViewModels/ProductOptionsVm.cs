using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.Storefront.Views.AdminProduct.ViewModels;

namespace DuxCommerce.Storefront.Views.ProductOption.ViewModels;

public class ProductOptionsVm
{
    public ProductLinksVm Links { get; set; }
    public ProductRow Product { get; set; }
    public IEnumerable<OptionVm> Options { get; set; }
}