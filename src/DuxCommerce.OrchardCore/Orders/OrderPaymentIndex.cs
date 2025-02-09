using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Orders;

public class OrderPaymentIndex : DuxIndex
{
    public OrderPaymentIndex(
        string rowId,
        string paymentMethodType,
        string paymentMethodName,
        string paymentReference,
        decimal amount,
        string status,
        string note,
        DateTime lastUpdatedUtc,
        DateTime createdAtUtc)
    {
        RowId = rowId;
        PaymentMethodType = paymentMethodType;
        PaymentMethodName = paymentMethodName;
        PaymentMethodType = paymentMethodType;
        PaymentReference = paymentReference;
        Amount = amount;
        Status = status;
        Note = note;
        LastUpdatedUtc = lastUpdatedUtc;
        CreatedAtUtc = createdAtUtc;
    }

    public sealed override string RowId { get; set; }
    public string PaymentMethodType { get; set; }
    public string PaymentMethodName { get; set; }
    public string PaymentReference { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public string Note { get; set; }
    public DateTime LastUpdatedUtc { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}

public class OrderPaymentIndexProvider : IndexProvider<OrderPart>
{
    public override void Describe(DescribeContext<OrderPart> context)
    {
        context.For<OrderPaymentIndex>()
            .Map(x =>
            {
                var row = (OrderRow)x.Row;

                return row.Payments.Select(p => new OrderPaymentIndex(
                    row.Id,
                    p.PaymentMethodType,
                    p.PaymentMethodName,
                    p.PaymentReference,
                    p.Amount,
                    p.Status,
                    p.Note,
                    p.LastUpdatedUtc,
                    p.CreatedAtUtc));
            });
    }
}