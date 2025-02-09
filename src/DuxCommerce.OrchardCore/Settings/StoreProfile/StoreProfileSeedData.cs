using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.OrchardCore.Settings.StoreProfile;

public static class StoreProfileSeedData
{
    public static StoreProfileRow CreateProfile(StateRow stateRow)
    {
        var profileRow = new StoreProfileRow
        {
            StoreName = "Your store name",
            ContactEmail = "contact@example.com",
            SenderEmail = "sender@example.com",
            PhoneNumber = "202-555-0156",
            BusinessName = "Your business name",
            TimeZoneId = "Pacific Standard Time",
            Currency = "USD",
            UnitSystem = "ImperialSystem",
            WeightUnit = "Ounce",
            LengthUnit = "Inch",
            Address = CreateAddress(stateRow)
        };

        return profileRow;
    }

    private static AddressRow CreateAddress(StateRow stateRow)
    {
        return new AddressRow
        {
            FirstName = "James",
            LastName = "King",
            AddressLine1 = "1 Kings Road",
            City = "Redmond",
            StateId = stateRow.Id,
            PostalCode = "98052",
            CountryCode = "US"
        };
    }
}