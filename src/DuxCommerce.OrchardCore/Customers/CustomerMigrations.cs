using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Customers;

public class CustomerMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(CustomerPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a customer."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.Customer, type => type
                .WithPart(nameof(CustomerPart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<CustomerIndex>(table => table
                .Column<string>(nameof(CustomerIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CustomerIndex.UserId), column => column.NotNull().WithLength(255))
                .Column<string>(nameof(CustomerIndex.PhoneNumber), column => column.Nullable().WithLength(50))
                .Column<string>(nameof(CustomerIndex.FirstName), column => column.NotNull().WithLength(50))
                .Column<string>(nameof(CustomerIndex.LastName), column => column.NotNull().WithLength(50))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CustomerIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CustomerIndex)}_{nameof(CustomerIndex.UserId)}",
                    nameof(CustomerIndex.UserId),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}