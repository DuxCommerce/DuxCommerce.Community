using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Catalog.CustomerFields;

public class CustomerFieldsMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(CustomerFieldsPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a customer field list."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.CustomerFields, type => type
                .WithPart(nameof(CustomerFieldsPart)));

        await SchemaBuilder
            .CreateMapIndexTableAsync<CustomerFieldsIndex>(table => table
                .Column<string>(nameof(CustomerFieldsIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CustomerFieldsIndex.ProductId), column => column.NotNull().WithLength(26))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CustomerFieldsIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CustomerFieldsIndex)}_{nameof(CustomerFieldsIndex.ProductId)}",
                    nameof(CustomerFieldsIndex.ProductId),
                    nameof(DuxDocument.DocumentId))
            );

        return 1;
    }
}