using System;
using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;

namespace DuxCommerce.Storefront.Views.Promotion.ViewModels;

public class PromotionIndexVm
{
    public IEnumerable<PromotionRow> Promotions { get; set; }
    public TimeZoneInfo TimeZone { get; set; }
}