using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.Storefront.Views.LinkedOption.ViewModels;

public class LinkedOptionVm
{
    public ProductOptionsRow ProductOptions { get; set; }
    public StoreBuilder.Catalog.DataTypes.LinkedOption LinkedOption { get; set; }
    public OptionRow SharedOption { get; set; }
}