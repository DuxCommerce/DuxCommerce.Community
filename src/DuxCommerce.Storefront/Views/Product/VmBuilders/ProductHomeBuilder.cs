using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Products;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Builders;
using DuxCommerce.Storefront.Views.Product.ViewModels;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Product.VmBuilders;

public class ProductHomeBuilder(
    IContentManager contentManager,
    ProductOptionsUseCases productOptionsUseCases,
    ProductHomeUseCases productHomeUseCases,
    CategoryMenuBuilder categoryMenuBuilder)
{
    public async Task<ProductHome> BuildModel(string userId, ContentItem productItem)
    {
        var hasPublished = await contentManager.HasPublishedVersionAsync(productItem);
        var productHome = new ProductHome
        {
            CategoryMenuVm = await categoryMenuBuilder.Build(),
            ImagesVm = new ProductImagesVm { Images = productItem.As<ProductImagePart>().Image },
            AddToCartVm = new AddToCartVm { HasPublished = hasPublished }
        };

        var product = productItem.As<ProductPart>().Row;
        var details = await productHomeUseCases.GetProductDetails(userId, product);

        productHome.GeneralVm = new ProductGeneralVm { Product = details.Product };
        productHome.PricesVm = new ProductPricesVm { Prices = details.Prices, Currency = details.Currency };
        productHome.DescriptionVm = new ProductDescriptionVm { Description = details.Product.Description };

        var optionRows = await productOptionsUseCases.GetAllOptions(productItem.ContentItemId);
        
        productHome.OptionsVm = new ProductOptionsVm { Options = optionRows };

        return productHome;
    }
}