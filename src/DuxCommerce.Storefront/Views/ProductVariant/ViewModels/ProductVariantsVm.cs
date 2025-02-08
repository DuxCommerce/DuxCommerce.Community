using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.Storefront.Views.AdminProduct.ViewModels;

namespace DuxCommerce.Storefront.Views.ProductVariant.ViewModels;

public class ProductVariantsVm
{
    public ProductRow Product { get; set; }
    public List<VariantModel> Variants { get; set; } = new();
    public ProductLinksVm Links { get; set; }
}