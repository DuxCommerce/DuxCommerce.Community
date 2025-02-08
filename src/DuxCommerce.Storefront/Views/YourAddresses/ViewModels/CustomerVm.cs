using DuxCommerce.StoreBuilder.Customers.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.YourAddresses.ViewModels;

public class CustomerVm
{
    public AccountLinksVm AccountLinks { get; set; }
    public CustomerRow Customer { get; set; }
}