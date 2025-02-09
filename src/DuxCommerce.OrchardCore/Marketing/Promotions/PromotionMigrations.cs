using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Marketing.Promotions;

public class PromotionMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(PromotionPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a promotion."));
        
        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.Promotion, type => type
                .WithPart(nameof(PromotionPart)));

        return 1;
    }

    public async Task<int> UpdateFrom1()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<PromotionIndex>(table => table
                .Column<string>(nameof(PromotionIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(PromotionIndex.Name), column => column.NotNull().WithLength(50))
                .Column<DateTime>(nameof(PromotionIndex.StartTime), column => column.NotNull())
                .Column<DateTime>(nameof(PromotionIndex.EndTime), column => column.NotNull())
                .Column<bool>(nameof(PromotionIndex.Activated), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<PromotionIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(PromotionIndex)}_{nameof(PromotionIndex.RowId)}",
                    nameof(PromotionIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<PromotionIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(PromotionIndex)}_{nameof(PromotionIndex.StartTime)}_{nameof(PromotionIndex.EndTime)}",
                    nameof(PromotionIndex.StartTime),
                    nameof(PromotionIndex.EndTime),
                    nameof(PromotionIndex.Activated),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}