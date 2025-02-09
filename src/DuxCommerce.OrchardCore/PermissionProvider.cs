using OrchardCore.Security.Permissions;

namespace DuxCommerce.OrchardCore;

public class PermissionProvider : IPermissionProvider
{
    public static readonly Permission ManageOrders = new("ManageOrders", "Manage Orders");
    
    public static readonly Permission ManageProducts = new("ManageProducts", "Manage Products");
    public static readonly Permission ManageSharedOptions = new("ManageSharedOptions", "Manage Shared Options");
    public static readonly Permission ManageInventory = new("ManageInventory", "Manage Inventory");
    public static readonly Permission ManageCategories = new("ManageCategories", "Manage Categories");
    
    public static readonly Permission ManageCustomers = new("ManageCustomers", "Manage Customers");
    public static readonly Permission ManageMarketing = new("ManageMarketing", "Manage Marketing");
    
    public static readonly Permission ManageStoreProfile = new("Store Profile", "Manage Store Profile");
    public static readonly Permission ManageShippingSettings  = new("ManageShipping ", "Manage Shipping Settings");
    public static readonly Permission ManageTaxSettings = new("ManageTaxes", "Manage Tax Settings");
    public static readonly Permission ManagePaymentSettings = new("ManagePayment", "Manage Payment Settings");
    public static readonly Permission ManageCurrencySettings = new("ManageCurrencies", "Manage Currency Settings");
    public static readonly Permission ManageCountrySettings = new("ManageCountries", "Manage Country Settings");

    public Task<IEnumerable<Permission>> GetPermissionsAsync()
    {
        return Task.FromResult(GetPermissions());
    }

    public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
    {
        return new[]
        {
            new PermissionStereotype
            {
                Name = "Administrator",
                Permissions = GetPermissions()
            }
        };
    }

    private IEnumerable<Permission> GetPermissions()
    {
        return new[]
        {
            ManageOrders,
            
            ManageProducts,
            ManageSharedOptions,
            ManageInventory,
            ManageCategories,
            
            ManageCustomers,
            ManageMarketing,
            
            ManageStoreProfile,
            ManageShippingSettings,
            ManageTaxSettings,
            ManagePaymentSettings,
            ManageCurrencySettings,
            ManageCountrySettings
        };
    }
}