using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DuxCommerce.Storefront.Views.Checkout.ViewModels;

public static class AddressesExtensions
{
    public static bool Validate(this CheckoutAddressesVm model, List<ValidationResult> validationResults)
    {
        bool shippingValidated;

        var billingAddress = model.BillingAddress.AddressVm.Address;
        var validationContext = new ValidationContext(billingAddress);

        var billingValidated = !string.IsNullOrEmpty(model.BillingAddress.AddressId) ||
                               Validator.TryValidateObject(billingAddress, validationContext, validationResults, true);

        if (!model.SameAsBillingAddress)
        {
            var shippingAddress = model.ShippingAddress.AddressVm.Address;
            validationContext = new ValidationContext(shippingAddress);

            shippingValidated = !string.IsNullOrEmpty(model.ShippingAddress.AddressId) ||
                                Validator.TryValidateObject(shippingAddress, validationContext, validationResults,
                                    true);
        }
        else
        {
            shippingValidated = billingValidated;
        }


        return billingValidated && shippingValidated;
    }
}