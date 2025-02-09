using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Marketing.GiftCards;

public class GiftCardMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(GiftCardPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a gift card."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.GiftCard, type => type
                .WithPart(nameof(GiftCardPart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<GiftCardIndex>(table => table
                .Column<string>(nameof(GiftCardIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(GiftCardIndex.Name), column => column.NotNull().WithLength(50))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<GiftCardIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(GiftCardIndex)}_{nameof(GiftCardIndex.RowId)}",
                    nameof(GiftCardIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}