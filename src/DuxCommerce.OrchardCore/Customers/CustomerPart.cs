using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Customers.DataTypes;

namespace DuxCommerce.OrchardCore.Customers;

public class CustomerPart : DuxPart<CustomerRow>
{
    public sealed override CustomerRow Row { get; set; } = new();
}