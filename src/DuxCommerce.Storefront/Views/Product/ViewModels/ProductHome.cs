using DuxCommerce.Storefront.Views.StoreHome.ViewModels;

namespace DuxCommerce.Storefront.Views.Product.ViewModels;

public class ProductHome
{
    public CategoryMenuVm CategoryMenuVm { get; set; }
    public ProductGeneralVm GeneralVm { get; set; }
    public ProductImagesVm ImagesVm { get; set; }
    public ProductPricesVm PricesVm { get; set; }
    public ProductOptionsVm OptionsVm { get; set; }
    public AddToCartVm AddToCartVm { get; set; }
    public ProductDescriptionVm DescriptionVm { get; set; }
}