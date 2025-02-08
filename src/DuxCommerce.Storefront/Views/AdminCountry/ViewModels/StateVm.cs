using DuxCommerce.StoreBuilder.Settings.Requests;

namespace DuxCommerce.Storefront.Views.AdminCountry.ViewModels;

public class StateVm
{
    public string CountryId { get; set; }
    public StateModel StateModel { get; set; } = new();
}