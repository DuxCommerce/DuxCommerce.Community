using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Products;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;

namespace DuxCommerce.Storefront.Handlers;

public class ProductPartHandler : ContentPartHandler<ProductPart>
{
    public override Task ClonedAsync(CloneContentContext context, ProductPart part)
    {
        // Todo: investigate why context.CloneContentItem.Content and context.CloneContentItem.Elements are different

        var clonedPart = context.CloneContentItem.As<ProductPart>();

        clonedPart.Row.Id = context.CloneContentItem.ContentItemId;

        clonedPart.Apply();

        return Task.CompletedTask;
    }
}