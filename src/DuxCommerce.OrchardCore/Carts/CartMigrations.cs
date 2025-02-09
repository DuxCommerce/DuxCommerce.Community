using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Carts;

public class CartMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(CartPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a cart."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.Cart, type => type
                .WithPart(nameof(CartPart))
            );

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<CartIndex>(table => table
                .Column<string>(nameof(CartIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CartIndex.ShopperCartId), column => column.NotNull().WithLength(36))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CartIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CartIndex)}_{nameof(CartIndex.ShopperCartId)}",
                    nameof(CartIndex.ShopperCartId),
                    nameof(DuxDocument.DocumentId))
            );

        // This is needed when updating cart
        await SchemaBuilder
            .AlterIndexTableAsync<CartIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CartIndex)}_{nameof(CartIndex.RowId)}",
                    nameof(CartIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        // Todo: figure out how to purge old carts and add index for the query

        return 2;
    }

    public async Task<int> UpdateFrom2Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<CartItemIndex>(table => table
                .Column<string>(nameof(CartItemIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CartItemIndex.CartItemId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CartItemIndex.ProductId), column => column.NotNull().WithLength(26))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CartItemIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CartItemIndex)}_{nameof(CartItemIndex.ProductId)}",
                    nameof(CartItemIndex.ProductId),
                    nameof(DuxDocument.DocumentId))
            );

        return 3;
    }

    public async Task<int> UpdateFrom3Async()
    {
        await SchemaBuilder
            .AlterIndexTableAsync<CartIndex>(table => table
                .AddColumn<DateTime>(nameof(CartIndex.LastUpdatedUtc),
                    column => column.NotNull().WithDefault(DateTime.UtcNow))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CartIndex>(table => table
                .AddColumn<DateTime>(nameof(CartIndex.CreatedAtUtc),
                    column => column.NotNull().WithDefault(DateTime.UtcNow))
            );

        return 4;
    }
}