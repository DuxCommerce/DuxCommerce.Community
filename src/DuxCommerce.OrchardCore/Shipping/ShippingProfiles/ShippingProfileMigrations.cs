using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Shipping.ShippingProfiles;

public class ShippingProfileMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(ShippingProfilePart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a shipping profile."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.ShippingProfile, type => type
                .WithPart(nameof(ShippingProfilePart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<ShippingProfileIndex>(table => table
                .Column<string>(nameof(ShippingProfileIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<bool>(nameof(ShippingProfileIndex.IsDefault), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<ShippingProfileIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(ShippingProfileIndex)}_{nameof(ShippingProfileIndex.RowId)}",
                    nameof(ShippingProfileIndex.RowId),
                    nameof(ShippingProfileIndex.IsDefault),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}