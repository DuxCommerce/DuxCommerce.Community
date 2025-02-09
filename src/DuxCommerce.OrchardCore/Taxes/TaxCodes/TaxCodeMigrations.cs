using DuxCommerce.OrchardCore.Shared;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Environment.Shell.Scope;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Taxes.TaxCodes;

public class TaxCodeMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(TaxCodePart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a tax code."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.TaxCode, type => type
                .WithPart(nameof(TaxCodePart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<TaxCodeIndex>(table => table
                .Column<string>(nameof(TaxCodeIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(TaxCodeIndex.Name), column => column.NotNull().WithLength(50))
                .Column<bool>(nameof(TaxCodeIndex.IsDefault), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<TaxCodeIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(TaxCodeIndex)}_{nameof(TaxCodeIndex.RowId)}",
                    nameof(TaxCodeIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }

    public int UpdateFrom2Async()
    {
        ShellScope.AddDeferredTask(async scope =>
        {
            var repo = scope.ServiceProvider.GetRequiredService<ITaxCodeSeeder>();
            var rows = TaxCodeSeedData.GetCodes();
            await repo.CreateMany(rows);
        });

        return 3;
    }
}