using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Payments.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Payments;

public class PaymentMethodIndex : DuxIndex
{
    public PaymentMethodIndex(
        string rowId,
        string displayName,
        string methodType,
        string setupController,
        string setupAction,
        string instructions,
        int displayOrder,
        bool enabled)
    {
        RowId = rowId;
        DisplayName = displayName;
        MethodType = methodType;
        SetupController = setupController;
        SetupAction = setupAction;
        DisplayOrder = displayOrder;
        Enabled = enabled;
    }

    public sealed override string RowId { get; set; }
    public string DisplayName { get; set; }
    public string MethodType { get; set; }
    public string SetupController { get; set; }
    public string SetupAction { get; set; }
    public int DisplayOrder { get; set; }
    public bool Enabled { get; set; }
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
                    row.SetupController,
                    row.SetupAction,
                    row.Instructions,
                    row.DisplayOrder,
                    row.Enabled);
            });
    }
}