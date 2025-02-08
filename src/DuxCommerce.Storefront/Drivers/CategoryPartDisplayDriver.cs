using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Categories;
using DuxCommerce.StoreBuilder.Catalog.Core;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.Storefront.Views.AdminCategory.ViewModels;
using DuxCommerce.Storefront.Views.AdminCategory.VmBuilders;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.Storefront.Drivers;

public class CategoryPartDisplayDriver(CategoryPartVmBuilder categoryPartVmBuilder)
    : ContentPartDisplayDriver<CategoryPart>
{
    public override IDisplayResult Edit(CategoryPart part, BuildPartEditorContext context)
    {
        return Combine(
            Initialize<CategoryLinksVm>("CategoryLinks", viewModel => BuildLinksModel(part, viewModel))
                .Location("Content:1.0"),
            Initialize<CategoryEditVm>(GetEditorShapeType(context),
                async viewModel => await BuildModel(part, viewModel))
        );
    }

    public override async Task<IDisplayResult> UpdateAsync(CategoryPart part, UpdatePartEditorContext context)
    {
        var viewModel = new CategoryEditVm();

        if (!await context.Updater.TryUpdateModelAsync(viewModel, Prefix))
            return await EditAsync(part, context);

        part.Row.Id = part.ContentItem.ContentItemId;
        part.Row = CategoryCore.updateCategory((CategoryRow)part.Row, viewModel.Category);

        return await EditAsync(part, context);
    }

    private void BuildLinksModel(CategoryPart part, CategoryLinksVm viewModel)
    {
        if (part.ContentItem?.Id > 0)
        {
            viewModel.ContentItem = part.ContentItem;

            viewModel.EditLink = true;
        }
    }

    private Task BuildModel(CategoryPart part, CategoryEditVm viewModel)
    {
        if (part.ContentItem.Id > 0)
            return categoryPartVmBuilder.BuildEditModel(part, viewModel);

        return categoryPartVmBuilder.BuildCreateModel(viewModel);
    }
}