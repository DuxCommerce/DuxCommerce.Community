using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Shipping.ShippingOrigins;

public class ShippingOriginMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(ShippingOriginPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a shipping origin."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.ShippingOrigin, type => type
                .WithPart(nameof(ShippingOriginPart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<ShippingOriginIndex>(table => table
                .Column<string>(nameof(ShippingOriginIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<bool>(nameof(ShippingOriginIndex.IsDefault), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<ShippingOriginIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(ShippingOriginIndex)}_{nameof(ShippingOriginIndex.RowId)}",
                    nameof(ShippingOriginIndex.RowId),
                    nameof(ShippingOriginIndex.IsDefault),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}