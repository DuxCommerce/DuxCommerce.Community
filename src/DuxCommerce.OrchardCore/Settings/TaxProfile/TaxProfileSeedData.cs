using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Settings.Requests;

namespace DuxCommerce.OrchardCore.Settings.TaxProfile;

public class TaxProfileSeedData
{
    public static TaxProfileModel CreateProfile(StateRow state)
    {
        return new TaxProfileModel
        {
            TaxCalculationType = "BaseOnShippingAddress",
            PricesIncludeTax = false,
            BreakdownTaxOnBackEnd = false,
            BreakdownTaxOnFrontEnd = false,

            DefaultTaxAddress = new TaxAddressModel
            {
                CountryCode = "US",
                StateId = state.Id
            }
        };
    }
}