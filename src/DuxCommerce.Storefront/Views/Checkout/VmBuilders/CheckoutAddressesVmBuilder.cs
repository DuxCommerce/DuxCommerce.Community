using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.Checkout.UseCases;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.Storefront.Views.Checkout.ViewModels;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.Shared.VmBuilders;
using DuxCommerce.Storefront.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Checkout.VmBuilders;

public class CheckoutAddressesVmBuilder(
    CheckoutUseCases checkoutUseCases,
    ICountryStore countryStore,
    IStateStore stateStore,
    AddressVmBuilder addressVmBuilder,
    MiniCartVmBuilder miniCartVmBuilder)
{
    public async Task<CheckoutAddressesVm> BuildEditModel(ShopperInfo shopperInfo)
    {
        var (billingAddress, combinedAddresses, cart) = await checkoutUseCases.GetBillingAddresses(shopperInfo);
        var addressItems = await GetAddressListItems(combinedAddresses.ToList());

        var billingAddressVm = await CreateBillingAddress(addressItems, billingAddress);

        var shippingAddressVm = await CreateShippingAddress(shopperInfo, addressItems);

        return new CheckoutAddressesVm
        {
            Steps = new CheckoutStepsVm { CheckAddresses = true },
            BillingAddress = billingAddressVm,
            SameAsBillingAddress = cart.SameAsBillingAddress,
            ShippingAddress = shippingAddressVm,
            MiniCart = await miniCartVmBuilder.GetMiniCart(cart)
        };
    }

    public async Task<CheckoutAddressesVm> BuildEditModel(ShopperInfo shopperInfo, CheckoutAddressesVm model)
    {
        var (_, combinedAddresses, cart) = await checkoutUseCases.GetBillingAddresses(shopperInfo);
        var addressItems = await GetAddressListItems(combinedAddresses.ToList());

        model.Steps = new CheckoutStepsVm { CheckAddresses = true };

        await UpdateBillingAddress(model, addressItems);

        await UpdateShippingAddress(model, addressItems);

        model.MiniCart = await miniCartVmBuilder.GetMiniCart(cart);

        return model;
    }

    private async Task<CheckoutAddressVm> CreateBillingAddress(List<SelectListItem> addressItems,
        AddressRow billingAddress)
    {
        var billingCountries = await countryStore.GetBillingCountries();

        var billingAddressVm = new CheckoutAddressVm
        {
            Addresses = addressItems,
            AddressId = (billingAddress ?? new AddressRow()).Id,
            AddressVm = await CreateAddress(billingCountries, "BillingAddress")
        };

        return billingAddressVm;
    }

    private async Task<CheckoutAddressVm> CreateShippingAddress(ShopperInfo shopperInfo,
        List<SelectListItem> addressItems)
    {
        var shippingAddress = await checkoutUseCases.GetShippingAddress(shopperInfo);
        var shippingCountries = await countryStore.GetShippingCountries();

        var shippingAddressVm = new CheckoutAddressVm
        {
            Addresses = addressItems,
            AddressId = (shippingAddress ?? new AddressRow()).Id,
            AddressVm = await CreateAddress(shippingCountries, "ShippingAddress")
        };

        return shippingAddressVm;
    }

    private async Task UpdateBillingAddress(CheckoutAddressesVm model, List<SelectListItem> addressItems)
    {
        model.BillingAddress.Addresses = addressItems;

        var billingCountries = (await countryStore.GetBillingCountries()).ToList();
        await UpdateAddress(billingCountries, "BillingAddress", model.BillingAddress.AddressVm);
    }

    private async Task UpdateShippingAddress(CheckoutAddressesVm model, List<SelectListItem> addressItems)
    {
        model.ShippingAddress.Addresses = addressItems;

        var shippingCountries = await countryStore.GetShippingCountries();
        await UpdateAddress(shippingCountries, "ShippingAddress", model.ShippingAddress.AddressVm);
    }

    private async Task<AddressVm> CreateAddress(IEnumerable<CountryRow> countries, string suffix)
    {
        var addressVm = new AddressVm { Address = new AddressRow(), Suffix = suffix };

        await addressVmBuilder.PopulateCountries(addressVm, countries.ToList());

        return addressVm;
    }

    private async Task UpdateAddress(IEnumerable<CountryRow> countries, string suffix, AddressVm model)
    {
        model.Suffix = suffix;

        await addressVmBuilder.PopulateCountries(model, countries.ToList());
    }

    private async Task<List<SelectListItem>> GetAddressListItems(List<AddressRow> combinedAddresses)
    {
        var countries = await countryStore.GetCountries(combinedAddresses.Select(x => x.CountryCode));
        var states = await stateStore.GetMany(combinedAddresses.Select(x => x.StateId));

        return combinedAddresses.ToListItems(countries, states).ToList();
    }
}