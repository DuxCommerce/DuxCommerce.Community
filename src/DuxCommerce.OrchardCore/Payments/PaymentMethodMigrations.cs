using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Payments;

public class PaymentMethodMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(PaymentMethodPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a payment method."));
        
        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.PaymentMethod, type => type
                .WithPart(nameof(PaymentMethodPart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<PaymentMethodIndex>(table => table
                .Column<string>(nameof(PaymentMethodIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(PaymentMethodIndex.DisplayName), column => column.NotNull().WithLength(100))
                .Column<string>(nameof(PaymentMethodIndex.MethodType), column => column.NotNull().WithLength(50))
                .Column<string>(nameof(PaymentMethodIndex.SetupController), column => column.Nullable().WithLength(50))
                .Column<string>(nameof(PaymentMethodIndex.SetupAction), column => column.Nullable().WithLength(50))
                .Column<int>(nameof(PaymentMethodIndex.DisplayOrder), column => column.NotNull())
                .Column<bool>(nameof(PaymentMethodIndex.Enabled), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<PaymentMethodIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(PaymentMethodIndex)}_{nameof(PaymentMethodIndex.RowId)}",
                    nameof(PaymentMethodIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}