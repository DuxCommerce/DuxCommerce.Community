using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.OrchardCore.Catalog.Products;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Views.AdminProduct.ViewModels;
using DuxCommerce.Storefront.Views.AdminProduct.VmBuilders;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.Storefront.Drivers;

public class ProductPartDisplayDriver(ProductPartVmBuilder productPartVmBuilder, ProductUseCases productUseCases)
    : ContentPartDisplayDriver<ProductPart>
{
    public override IDisplayResult Edit(ProductPart part, BuildPartEditorContext context)
    {
        return Combine(
            Initialize<ProductLinksVm>("ProductLinks", viewModel => BuildLinksModel(part, viewModel))
                .Location("Content:1.0"),
            Initialize<ProductEditVm>(GetEditorShapeType(context), async viewModel => await BuildModel(part, viewModel))
        );
    }

    public override async Task<IDisplayResult> UpdateAsync(ProductPart part, UpdatePartEditorContext context)
    {
        var viewModel = new ProductEditVm();

        if (!await context.Updater.TryUpdateModelAsync(viewModel, Prefix))
            return await EditAsync(part, context);

        part.Row.Id = part.ContentItem.ContentItemId;

        var result = await productUseCases.UpdateProduct((ProductRow)part.Row, viewModel.Product);

        if (result.Succeeded)
            part.Row = result.Result;
        else
            context.Updater.ModelState.AddModelError("", result.Error.ToMessage());

        return await EditAsync(part, context);
    }

    private void BuildLinksModel(ProductPart part, ProductLinksVm viewModel)
    {
        if (part.ContentItem?.Id > 0)
        {
            viewModel.ContentItem = part.ContentItem;

            viewModel.EditLink = true;
        }
    }

    private Task BuildModel(ProductPart part, ProductEditVm viewModel)
    {
        if (part.ContentItem.Id > 0)
            return productPartVmBuilder.BuildEditModel(part, viewModel);

        return productPartVmBuilder.BuildCreateModel(viewModel);
    }
}