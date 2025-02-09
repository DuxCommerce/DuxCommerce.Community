using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Marketing.Coupons;

public class CouponMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(CouponPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a coupon."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.Coupon, type => type
                .WithPart(nameof(CouponPart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<CouponIndex>(table => table
                .Column<string>(nameof(CouponIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CouponIndex.Name), column => column.NotNull().WithLength(50))
                .Column<string>(nameof(CouponIndex.Code), column => column.NotNull().WithLength(50))
                .Column<DateTime>(nameof(CouponIndex.StartTime), column => column.NotNull())
                .Column<DateTime>(nameof(CouponIndex.EndTime), column => column.NotNull())
                .Column<bool>(nameof(CouponIndex.Activated),
                    column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CouponIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CouponIndex)}_{nameof(CouponIndex.RowId)}",
                    nameof(CouponIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CouponIndex>(table => table
                    .CreateIndex(
                        $"IDX_{nameof(CouponIndex)}_{nameof(CouponIndex.Code)}",
                        nameof(CouponIndex.Code),
                        nameof(DuxDocument.DocumentId))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CouponIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CouponIndex)}_{nameof(CouponIndex.StartTime)}_{nameof(CouponIndex.EndTime)}",
                    nameof(CouponIndex.StartTime),
                    nameof(CouponIndex.EndTime),
                    nameof(CouponIndex.Activated),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }
}