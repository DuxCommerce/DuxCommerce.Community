using DuxCommerce.StoreBuilder.Catalog.Requests;

namespace DuxCommerce.Storefront.Views.ProductOption.ViewModels;

public class PrivateOptionChoiceVm
{
    public string ProductId { get; set; }
    public OptionChoiceModel Choice { get; set; }
}