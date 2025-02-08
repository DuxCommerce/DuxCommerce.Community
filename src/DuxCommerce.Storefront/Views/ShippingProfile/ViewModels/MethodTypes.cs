using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Shipping.DomainTypes;

namespace DuxCommerce.Storefront.Views.ShippingProfile.ViewModels;

public class MethodType
{
    public string Name { get; set; }
    public string Type { get; set; }
}

public static class MethodTypes
{
    public static List<MethodType> GetAll()
    {
        return new List<MethodType>
        {
            new()
            {
                Name = "By Weight",
                Type = nameof(ShippingMethodType.ByWeight)
            },
            new()
            {
                Name = "By Quantity",
                Type = nameof(ShippingMethodType.ByQuantity)
            },
            new()
            {
                Name = "By Order Total",
                Type = nameof(ShippingMethodType.ByOrderTotal)
            }
        };
    }
}