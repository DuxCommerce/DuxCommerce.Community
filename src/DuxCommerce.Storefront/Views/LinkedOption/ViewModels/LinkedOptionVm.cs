using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.Storefront.Views.AdminProduct.ViewModels;

namespace DuxCommerce.Storefront.Views.LinkedOption.ViewModels;

public class LinkedOptionVm
{
    public ProductLinksVm Links { get; set; }
    public ProductOptionsRow ProductOptions { get; set; }
    public OptionRow SharedOption { get; set; }
}