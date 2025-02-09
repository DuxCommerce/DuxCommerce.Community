using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Marketing.BulkDiscounts;

public class BulkDiscountMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(BulkDiscountPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a product bulk discount."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.BulkDiscount, type => type
                .WithPart(nameof(BulkDiscountPart)));

        await SchemaBuilder
            .CreateMapIndexTableAsync<BulkDiscountIndex>(table => table
                .Column<string>(nameof(BulkDiscountIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(BulkDiscountIndex.ProductId),
                    column => column.NotNull().WithLength(26))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<BulkDiscountIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(BulkDiscountIndex)}_{nameof(BulkDiscountIndex.ProductId)}",
                    nameof(BulkDiscountIndex.ProductId),
                    nameof(DuxDocument.DocumentId))
            );

        return 1;
    }
}