using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace DuxCommerce.OrchardCore.Carts;

public class CartWidgetMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.CartWidget, type => type
                .WithPart(nameof(CartWidgetPart))
                .Stereotype("Widget"));

        return 1;
    }
}