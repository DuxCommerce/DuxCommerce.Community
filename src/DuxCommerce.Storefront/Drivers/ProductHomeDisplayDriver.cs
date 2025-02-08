using DuxCommerce.Storefront.Views.Product.ViewModels;
using DuxCommerce.Storefront.Views.StoreHome.ViewModels;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.Storefront.Drivers;

public class ProductHomeDisplayDriver : DisplayDriver<ProductHome>
{
    public override IDisplayResult Display(ProductHome home)
    {
        return Combine(
            Initialize<CategoryMenuVm>("CategoryMenu", model => UpdateMenuModel(model, home)).Location("Nav:5"),
            Initialize<ProductImagesVm>("ProductImages", model => UpdateImagesModel(model, home)).Location("Aside:5"),
            Initialize<ProductGeneralVm>("ProductGeneral", model => UpdateGeneralModel(model, home))
                .Location("Content:5"),
            Initialize<ProductPricesVm>("ProductPrices", model => UpdatePricesModel(model, home))
                .Location("Content:10"),
            Initialize<ProductOptionsVm>("ProductOptions", model => UpdateOptionsModel(model, home))
                .Location("Content:15"),
            Initialize<AddToCartVm>("AddToCart", model => UpdateAddToCartModel(model, home)).Location("Content:20"),
            Initialize<ProductDescriptionVm>("ProductDescription", model => UpdateDescriptionModel(model, home))
                .Location("Content:25")
        );
    }

    private void UpdateMenuModel(CategoryMenuVm model, ProductHome home)
    {
        model.Parents = home.CategoryMenuVm.Parents;
        model.ChildMap = home.CategoryMenuVm.ChildMap;
        model.CategoryMap = home.CategoryMenuVm.CategoryMap;
    }

    private void UpdateImagesModel(ProductImagesVm model, ProductHome home)
    {
        model.Images = home.ImagesVm.Images;
    }

    private void UpdateGeneralModel(ProductGeneralVm model, ProductHome home)
    {
        model.Product = home.GeneralVm.Product;
    }

    private void UpdatePricesModel(ProductPricesVm model, ProductHome home)
    {
        model.Prices = home.PricesVm.Prices;
        model.Currency = home.PricesVm.Currency;
    }

    private void UpdateOptionsModel(ProductOptionsVm model, ProductHome home)
    {
        model.Options = home.OptionsVm.Options;
    }

    private void UpdateAddToCartModel(AddToCartVm model, ProductHome home)
    {
        model.HasPublished = home.AddToCartVm.HasPublished;
    }

    private void UpdateDescriptionModel(ProductDescriptionVm model, ProductHome home)
    {
        model.Description = home.DescriptionVm.Description;
    }
}