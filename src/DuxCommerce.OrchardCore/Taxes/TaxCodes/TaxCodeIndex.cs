using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Taxes.TaxCodes;

public class TaxCodeIndex(string rowId, string name, bool isDefault) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string Name { get; set; } = name;
    public bool IsDefault { get; set; } = isDefault;
}

public class TaxCodeIndexProvider : IndexProvider<TaxCodePart>
{
    public override void Describe(DescribeContext<TaxCodePart> context)
    {
        context.For<TaxCodeIndex>()
            .Map(x =>
            {
                var row = (TaxCodeRow)x.Row;

                return new TaxCodeIndex(row.Id, row.Name, row.IsDefault);
            });
    }
}