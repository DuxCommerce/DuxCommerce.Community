using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Orders;

public class OrderMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(OrderPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into an order."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.Order, type => type
                .WithPart(nameof(OrderPart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<OrderIndex>(table => table
                .Column<string>(nameof(OrderIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(OrderIndex.OrderNumber), column => column.NotNull().WithLength(50))
                .Column<string>(nameof(OrderIndex.UserId), column => column.NotNull().WithLength(255))
                .Column<decimal>(nameof(OrderIndex.OrderTotal), column => column.NotNull())
                .Column<string>(nameof(OrderIndex.ShippingStatus), column => column.NotNull().WithLength(50))
                .Column<string>(nameof(OrderIndex.PaymentStatus), column => column.NotNull().WithLength(50))
                .Column<string>(nameof(OrderIndex.OrderStatus), column => column.NotNull().WithLength(50))
                .Column<DateTime>(nameof(OrderIndex.LastUpdatedUtc), column => column.NotNull())
                .Column<DateTime>(nameof(OrderIndex.CreatedAtUtc), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<OrderIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(OrderIndex)}_{nameof(OrderIndex.UserId)}",
                    nameof(OrderIndex.UserId),
                    nameof(DuxDocument.DocumentId))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<OrderIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(OrderIndex)}_{nameof(OrderIndex.OrderNumber)}",
                    nameof(OrderIndex.OrderNumber),
                    nameof(DuxDocument.DocumentId))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<OrderIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(OrderIndex)}_{nameof(OrderIndex.CreatedAtUtc)}",
                    nameof(OrderIndex.CreatedAtUtc),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }

    public async Task<int> UpdateFrom2Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<OrderPaymentIndex>(table => table
                .Column<string>(nameof(OrderPaymentIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(OrderPaymentIndex.PaymentMethodType), column => column.NotNull().WithLength(50))
                .Column<string>(nameof(OrderPaymentIndex.PaymentMethodName), column => column.NotNull().WithLength(100))
                .Column<string>(nameof(OrderPaymentIndex.PaymentReference), column => column.Nullable().WithLength(100))
                .Column<decimal>(nameof(OrderPaymentIndex.Amount), column => column.NotNull())
                .Column<string>(nameof(OrderPaymentIndex.Status), column => column.NotNull().WithLength(50))
                .Column<string>(nameof(OrderPaymentIndex.Note), column => column.Nullable().WithLength(100))
                .Column<DateTime>(nameof(OrderPaymentIndex.LastUpdatedUtc), column => column.NotNull())
                .Column<DateTime>(nameof(OrderPaymentIndex.CreatedAtUtc), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<OrderPaymentIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(OrderPaymentIndex)}_{nameof(OrderPaymentIndex.PaymentReference)}",
                    nameof(OrderPaymentIndex.PaymentReference),
                    nameof(DuxDocument.DocumentId))
            );

        return 3;
    }

    public async Task<int> UpdateFrom3Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<OrderItemIndex>(table => table
                .Column<string>(nameof(OrderItemIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(OrderItemIndex.OrderItemId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(OrderItemIndex.ProductId), column => column.NotNull().WithLength(26))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<OrderItemIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(OrderItemIndex)}_{nameof(OrderItemIndex.ProductId)}",
                    nameof(OrderItemIndex.ProductId),
                    nameof(DuxDocument.DocumentId))
            );

        return 4;
    }
    
    public async Task<int> UpdateFrom4Async()
    {
        await SchemaBuilder
            .CreateReduceIndexTableAsync<PromotionUsageIndex>(table => table
                .Column<string>(nameof(PromotionUsageIndex.PromotionId), column => column.NotNull().WithLength(26))
                .Column<int>(nameof(PromotionUsageIndex.Count))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<PromotionUsageIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(PromotionUsageIndex.PromotionId)}", 
                    nameof(PromotionUsageIndex.PromotionId))
            );

        return 5;
    }
    
    public async Task<int> UpdateFrom5Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<CustomerPromotionIndex>(table => table
                .Column<string>(nameof(OrderIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CustomerPromotionIndex.UserId), column => column.NotNull().WithLength(255))
                .Column<string>(nameof(CustomerPromotionIndex.PromotionId), column => column.NotNull().WithLength(26))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CustomerPromotionIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CustomerPromotionIndex.UserId)}_{nameof(CustomerPromotionIndex.PromotionId)}", 
                    nameof(CustomerPromotionIndex.UserId),
                    nameof(CustomerPromotionIndex.PromotionId))
            );

        return 6;
    }
    
    public async Task<int> UpdateFrom6Async()
    {
        await SchemaBuilder
            .CreateReduceIndexTableAsync<CouponUsageIndex>(table => table
                .Column<string>(nameof(CouponUsageIndex.CouponId), column => column.NotNull().WithLength(26))
                .Column<int>(nameof(CouponUsageIndex.Count))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CouponUsageIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CouponUsageIndex.CouponId)}", 
                    nameof(CouponUsageIndex.CouponId))
            );

        return 7;
    }
    
    public async Task<int> UpdateFrom7Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<CustomerCouponIndex>(table => table
                .Column<string>(nameof(OrderIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CustomerCouponIndex.UserId), column => column.NotNull().WithLength(255))
                .Column<string>(nameof(CustomerCouponIndex.CouponId), column => column.NotNull().WithLength(26))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CustomerCouponIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CustomerCouponIndex.UserId)}_{nameof(CustomerCouponIndex.CouponId)}", 
                    nameof(CustomerCouponIndex.UserId),
                    nameof(CustomerCouponIndex.CouponId))
            );

        return 8;
    }    
}