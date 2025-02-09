using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Settings.StoreProfile;

public class StoreProfileMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(StoreProfilePart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a store profile."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.StoreProfile, type => type
                .WithPart(nameof(StoreProfilePart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<StoreSettingsIndex>(table => table
                .Column<string>(nameof(StoreSettingsIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(StoreSettingsIndex.Name), column => column.NotNull().WithLength(100))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<StoreSettingsIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(StoreSettingsIndex)}_{nameof(StoreSettingsIndex.RowId)}",
                    nameof(StoreSettingsIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<StoreSettingsIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(StoreSettingsIndex)}_{nameof(StoreSettingsIndex.Name)}",
                    nameof(StoreSettingsIndex.Name),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}