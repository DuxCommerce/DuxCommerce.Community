using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Marketing.BulkDiscounts;

public class BulkDiscountIndex(string rowId, string productId) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string ProductId { get; set; } = productId;
}

public class BulkDiscountIndexProvider : IndexProvider<BulkDiscountPart>
{
    public override void Describe(DescribeContext<BulkDiscountPart> context)
    {
        context.For<BulkDiscountIndex>()
            .Map(x =>
            {
                var row = (BulkDiscountRow)x.Row;

                return new BulkDiscountIndex(row.Id, row.ProductId);
            });
    }
}