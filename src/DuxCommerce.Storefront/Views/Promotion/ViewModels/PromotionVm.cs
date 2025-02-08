using System;
using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Promotion.ViewModels;

public class PromotionVm
{
    public PromotionLinks Links { get; set; }
    public PromotionModel Promotion { get; set; }
    public IEnumerable<SelectListItem> PromotionTypes { get; set; }
    public IEnumerable<TypeItem> DiscountTypes { get; set; }
    public IEnumerable<TypeItem> ProductRules { get; set; }
    public IEnumerable<TypeItem> MinRules { get; set; }
    public IEnumerable<TypeItem> CustomerRules { get; set; }
    public IEnumerable<TypeItem> CountryRules { get; set; }
    public TimeZoneInfo TimeZone { get; set; }
}