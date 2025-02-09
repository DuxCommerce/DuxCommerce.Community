using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Catalog.MerchantFields;

public class MerchantFieldsMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(MerchantFieldsPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a merchant field list."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.MerchantFields, type => type
                .WithPart(nameof(MerchantFieldsPart)));

        await SchemaBuilder
            .CreateMapIndexTableAsync<MerchantFieldsIndex>(table => table
                .Column<string>(nameof(MerchantFieldsIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(MerchantFieldsIndex.ProductId), column => column.NotNull().WithLength(26))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<MerchantFieldsIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(MerchantFieldsIndex)}_{nameof(MerchantFieldsIndex.ProductId)}",
                    nameof(MerchantFieldsIndex.ProductId),
                    nameof(DuxDocument.DocumentId))
            );

        return 1;
    }
}