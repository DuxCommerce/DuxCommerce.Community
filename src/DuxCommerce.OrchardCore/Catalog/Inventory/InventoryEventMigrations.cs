using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Catalog.Inventory;

public class InventoryEventMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(InventoryEventPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into an inventory event."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.InventoryEvent, type => type
                .WithPart(nameof(InventoryEventPart)));

        await SchemaBuilder
            .CreateMapIndexTableAsync<InventoryEventIndex>(table => table
                .Column<string>(nameof(InventoryEventIndex.RowId),
                    column => column.NotNull().WithLength(26))
                .Column<string>(nameof(InventoryEventIndex.ProductId),
                    column => column.Nullable().WithLength(26))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<InventoryEventIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(InventoryEventIndex)}_{nameof(InventoryEventIndex.ProductId)}",
                    nameof(InventoryEventIndex.ProductId),
                    nameof(DuxDocument.DocumentId))
            );

        return 1;
    }
}