using DuxCommerce.StoreBuilder.Marketing.DataTypes;

namespace DuxCommerce.Storefront.Views.Promotion.ViewModels;

public class PromotionLinks
{
    public PromotionRow Promotion { get; set; }
    public bool General { get; set; }
    public bool Products { get; set; }
    public bool Categories { get; set; }
}