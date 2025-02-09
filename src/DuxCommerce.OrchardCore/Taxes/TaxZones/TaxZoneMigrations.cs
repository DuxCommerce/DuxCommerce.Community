using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Taxes.TaxZones;

public class TaxZoneMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(TaxZonePart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a tax zone."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.TaxZone, type => type
                .WithPart(nameof(TaxZonePart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<TaxZoneIndex>(table => table
                .Column<string>(nameof(TaxZoneIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(TaxZoneIndex.Name), column => column.NotNull().WithLength(50))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<TaxZoneIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(TaxZoneIndex)}_{nameof(TaxZoneIndex.RowId)}",
                    nameof(TaxZoneIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}