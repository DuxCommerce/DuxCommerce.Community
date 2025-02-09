using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Catalog.SharedOptions;

public class OptionMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(OptionPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a shared option."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.SharedOptions, type => type
                .WithPart(nameof(OptionPart)));

        await SchemaBuilder
            .CreateMapIndexTableAsync<OptionIndex>(table => table
                .Column<string>(nameof(OptionIndex.RowId), column => column.NotNull().WithLength(26))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<OptionIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(OptionIndex.RowId)}_{nameof(DuxDocument.DocumentId)}",
                    nameof(OptionIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        return 1;
    }
}