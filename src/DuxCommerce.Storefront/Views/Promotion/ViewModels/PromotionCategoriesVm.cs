using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Promotion.ViewModels;

public class PromotionCategoriesVm
{
    public PromotionRow Promotion { get; set; }
    public IEnumerable<CategoryTrail> CategoryTrails { get; set; }
    public IDictionary<string, ContentItem> CategoryMap { get; set; }
    public PromotionLinks Links { get; set; }
}