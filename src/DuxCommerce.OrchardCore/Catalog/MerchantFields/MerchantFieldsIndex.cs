using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Catalog.MerchantFields;

public class MerchantFieldsIndex(string rowId, string productId) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string ProductId { get; set; } = productId;
}

public class MerchantFieldListIndexProvider : IndexProvider<MerchantFieldsPart>
{
    public override void Describe(DescribeContext<MerchantFieldsPart> context)
    {
        context.For<MerchantFieldsIndex>()
            .Map(x =>
            {
                var row = (MerchantFieldsRow)x.Row;

                return new MerchantFieldsIndex(row.Id, row.ProductId);
            });
    }
}