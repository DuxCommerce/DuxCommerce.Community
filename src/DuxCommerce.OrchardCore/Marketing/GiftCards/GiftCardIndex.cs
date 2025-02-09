using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Marketing.GiftCards;

public class GiftCardIndex(string rowId, string name) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string Name { get; set; } = name;
}

public class GiftCardIndexProvider : IndexProvider<GiftCardPart>
{
    public override void Describe(DescribeContext<GiftCardPart> context)
    {
        context.For<GiftCardIndex>()
            .Map(x =>
            {
                var row = (GiftCardRow)x.Row;

                return new GiftCardIndex(row.Id, row.Name);
            });
    }
}