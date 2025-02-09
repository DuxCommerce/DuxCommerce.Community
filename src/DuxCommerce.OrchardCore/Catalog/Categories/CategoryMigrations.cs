using DuxCommerce.OrchardCore.Shared;
using OrchardCore.Autoroute.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Media.Fields;
using OrchardCore.Media.Settings;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Catalog.Categories;

public class CategoryMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(CategoryPart), partBuilder => partBuilder
                .WithDescription("Contains the most common fields of a category."));

        await definitionManager
            .AlterPartDefinitionAsync(nameof(CategoryImagePart), partBuilder => partBuilder
                .WithDescription("Contains image field of a category.")
                .WithField("Image", field => field
                    .OfType(nameof(MediaField))
                    .WithDisplayName("Category Image")
                    .WithSettings(new MediaFieldSettings { Multiple = false }))
            );

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.Category, typeBuilder => typeBuilder
                .WithPart(nameof(AutoroutePart),
                    settings => settings.WithSettings(new AutoroutePartSettings { AllowCustomPath = true, }))
                .WithPart(nameof(CategoryPart))
                .WithPart(nameof(CategoryImagePart))
            );

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<CategoryIndex>(table => table
                .Column<string>(nameof(CategoryIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CategoryIndex.Name), column => column.NotNull().WithLength(100))
                .Column<int>(nameof(CategoryIndex.SortOrder), column => column.NotNull())
                .Column<string>(nameof(CategoryIndex.ParentId), column => column.Nullable().WithLength(26))
                .Column<bool>(nameof(CategoryIndex.Featured), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CategoryIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CategoryIndex)}_{nameof(CategoryIndex.RowId)}",
                    nameof(CategoryIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CategoryIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CategoryIndex)}_{nameof(CategoryIndex.ParentId)}",
                    nameof(CategoryIndex.ParentId),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}