using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Customers.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Customers;

public class CustomerIndex(
    string rowId,
    string userId,
    string phoneNumber,
    string firstName,
    string lastName)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string UserId { get; set; } = userId;
    public string PhoneNumber { get; set; } = phoneNumber;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
}

public class CustomerIndexProvider : IndexProvider<CustomerPart>
{
    public override void Describe(DescribeContext<CustomerPart> context)
    {
        context.For<CustomerIndex>()
            .Map(x =>
            {
                var row = (CustomerRow)x.Row;

                return new CustomerIndex(
                    row.Id,
                    row.UserId,
                    row.PhoneNumber,
                    row.FirstName,
                    row.LastName);
            });
    }
}