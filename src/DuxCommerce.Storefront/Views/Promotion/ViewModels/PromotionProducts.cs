using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Promotion.ViewModels;

public class PromotionProducts
{
    public PromotionRow Promotion { get; set; }
    public IEnumerable<ContentItem> Products { get; set; }
    public int Count { get; set; }
}