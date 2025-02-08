using System;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.Storefront.Controllers;
using Microsoft.Extensions.Localization;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront;

public class AdminMenu(IStringLocalizer<AdminMenu> localizer) : INavigationProvider
{
    private readonly IStringLocalizer T = localizer;

    public ValueTask BuildNavigationAsync(string name, NavigationBuilder builder)
    {
        if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            return new ValueTask(Task.CompletedTask);

        builder.Add(T["Commerce"], content => content
            .Add(T["Orders"], T["Orders"].PrefixPosition("10"), orders => orders
                .Action(nameof(AdminOrderController.Index), typeof(AdminOrderController).ControllerName(),
                    new { area = Constants.AreaName })
                .Permission(PermissionProvider.ManageOrders)
                .LocalNav())
            .Add(T["Catalog"], T["Catalog"].PrefixPosition("20"), catalog => catalog
                .Add(T["Products"], T["Products"].PrefixPosition("22"), products => products
                    .Action(nameof(AdminProductController.Index), typeof(AdminProductController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageProducts)
                    .LocalNav())
                .Add(T["Shared Options"], T["Shared Options"].PrefixPosition("24"), options => options
                    .Action(nameof(SharedOptionController.Index), typeof(SharedOptionController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageSharedOptions)
                    .LocalNav())
                .Add(T["Inventory"], T["Inventory"].PrefixPosition("26"), inventory => inventory
                    .Action(nameof(InventoryController.Index), typeof(InventoryController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageInventory)
                    .LocalNav())
                .Add(T["Categories"], T["Categories"].PrefixPosition("28"), categories => categories
                    .Action(nameof(AdminCategoryController.Index), typeof(AdminCategoryController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageCategories)
                    .LocalNav())
            )
            .Add(T["Customers"], T["Customers"].PrefixPosition("30"), customers => customers
                .Action(nameof(AdminCustomerController.Index), typeof(AdminCustomerController).ControllerName(),
                    new { area = Constants.AreaName })
                .Permission(PermissionProvider.ManageCustomers)
                .LocalNav())
            .Add(T["Marketing"], T["Marketing"].PrefixPosition("40"), marketing => marketing
                .Add(T["Coupons"], coupons => coupons
                    .Action(nameof(CouponController.Index), typeof(CouponController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageMarketing)
                    .LocalNav())
                .Add(T["Promotions"], promotions => promotions
                    .Action(nameof(PromotionController.Index), typeof(PromotionController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageMarketing)
                    .LocalNav())
            )
            .Add(T["Settings"], T["Settings"].PrefixPosition("50"), settings => settings
                .Add(T["Store Profile"], profile => profile
                    .Action(nameof(StoreProfileController.Edit), typeof(StoreProfileController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageStoreProfile)
                    .LocalNav())
                .Add(T["Shipping"], region => region
                    .Action(nameof(ShippingProfileController.Index), typeof(ShippingProfileController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageShippingSettings)
                    .LocalNav())
                .Add(T["Taxes"], taxes => taxes
                    .Add(T["Tax Profile"], profile => profile
                        .Action(nameof(TaxProfileController.Edit), typeof(TaxProfileController).ControllerName(),
                            new { area = Constants.AreaName })
                        .Permission(PermissionProvider.ManageTaxSettings)
                        .LocalNav())
                    .Add(T["Tax Zones"], zones => zones
                        .Action(nameof(TaxZoneController.Index), typeof(TaxZoneController).ControllerName(),
                            new { area = Constants.AreaName })
                        .Permission(PermissionProvider.ManageTaxSettings)
                        .LocalNav())
                    .Add(T["Tax Codes"], codes => codes
                        .Action(nameof(TaxCodeController.Index), typeof(TaxCodeController).ControllerName(),
                            new { area = Constants.AreaName })
                        .Permission(PermissionProvider.ManageTaxSettings)
                        .LocalNav()))
                .Add(T["Payments"], payments => payments
                    .Action(nameof(PaymentMethodController.Index), typeof(PaymentMethodController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManagePaymentSettings)
                    .LocalNav())
                .Add(T["Currencies"], currencies => currencies
                    .Action(nameof(CurrencyController.Index), typeof(CurrencyController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageCurrencySettings)
                    .LocalNav())
                .Add(T["Countries"], countries => countries
                    .Action(nameof(AdminCountryController.Index), typeof(AdminCountryController).ControllerName(),
                        new { area = Constants.AreaName })
                    .Permission(PermissionProvider.ManageCountrySettings)
                    .LocalNav())
            )
        );

        return new ValueTask(Task.CompletedTask);
    }
}