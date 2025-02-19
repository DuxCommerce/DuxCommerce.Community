using DuxCommerce.OrchardCore.Shared;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Payments;

public class PaymentMethodIndex(
    string rowId,
    string displayName,
    string methodType,
    string moduleName,
    int displayOrder,
    bool enabled)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string DisplayName { get; set; } = displayName;
    public string MethodType { get; set; } = methodType;
    public string ModuleName { get; set; } = moduleName;
    public int DisplayOrder { get; set; } = displayOrder;
    public bool Enabled { get; set; } = enabled;
}

public class PaymentMethodIndexProvider : IndexProvider<PaymentMethodPart>
{
    public override void Describe(DescribeContext<PaymentMethodPart> context)
    {
        context.For<PaymentMethodIndex>()
            .Map(x =>
            {
                var row = x.Row;

                return new PaymentMethodIndex(
                    row.Id,
                    row.DisplayName,
                    row.MethodType,
                    row.ModuleName,
                    row.DisplayOrder,
                    row.Enabled);
            });
    }
}