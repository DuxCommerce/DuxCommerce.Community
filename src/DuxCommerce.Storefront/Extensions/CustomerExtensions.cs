using System.Linq;
using DuxCommerce.StoreBuilder.Customers.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Storefront.Extensions;

public static class CustomerExtensions
{
    public static AddressRow GetBillingAddress(this CustomerRow customer)
    {
        return customer.AddressBook.Single(x => x.Id == customer.BillingAddressId);
    }
}